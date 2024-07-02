using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Queries.GetProductsBySupplierId;

public class GetProductsBySupplierIdQueriesHandler : IRequestHandler<GetProductsBySupplierIdQueries, List<Product>>
{
    private readonly IProductRespository _productResository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMemoryCache _memoryCache;

    public GetProductsBySupplierIdQueriesHandler(IProductRespository productResository, IUnitOfWork unitOfWork, IMemoryCache memoryCache)
    {
        _productResository = productResository;
        _unitOfWork = unitOfWork;
        _memoryCache = memoryCache;
    }

    public async Task<List<Product>> Handle(GetProductsBySupplierIdQueries queries, CancellationToken cancellationToken)
    {
        const string cacheKey = "Product";

        if (!_memoryCache.TryGetValue(cacheKey, out List<Product> product))
        {
            product = await _productResository.GetProductsBySupplierIdAsync(queries.SupplierId);

            _memoryCache.Set(cacheKey, product,
                            new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(5)));
        }

        await _unitOfWork.Save(cancellationToken);

        return product;
    }
}
