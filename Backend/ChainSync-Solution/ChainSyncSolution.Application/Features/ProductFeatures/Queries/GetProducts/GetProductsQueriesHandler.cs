using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Queries.GetProducts;

public class GetProductsQueriesHandler : IRequestHandler<GetProductsQueries, List<Product>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRespository _productRespository; 
    private readonly IMemoryCache _memoryCache;

    public GetProductsQueriesHandler(
        IUnitOfWork unitOfWork,
        IProductRespository productRespository,
        IMemoryCache memoryCache)
    {
        _unitOfWork = unitOfWork;
        _productRespository = productRespository;
        _memoryCache = memoryCache;
    }

    public async Task<List<Product>> Handle(
        GetProductsQueries queries,
        CancellationToken cancellationToken)
    {
        const string cacheKey = "Product";

        if (!_memoryCache.TryGetValue(cacheKey, out List<Product> product))
        {
            product = await _productRespository.GetProductsAsync();

            _memoryCache.Set(cacheKey, product,
                            new MemoryCacheEntryOptions()
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(5)));
        }

        await _unitOfWork.Save(cancellationToken);

        return product;
    }
}
