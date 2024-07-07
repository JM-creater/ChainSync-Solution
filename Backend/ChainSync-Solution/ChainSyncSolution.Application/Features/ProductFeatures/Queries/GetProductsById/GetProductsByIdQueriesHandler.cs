using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Queries.GetProductsById;

public class GetProductsByIdQueriesHandler : IRequestHandler<GetProductsByIdQueries, Product?>
{
    private readonly IProductRespository _productRespository;
    private readonly IUnitOfWork _unitOfWork;

    public GetProductsByIdQueriesHandler(IProductRespository productRespository, IUnitOfWork unitOfWork)
    {
        _productRespository = productRespository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Product?> Handle(GetProductsByIdQueries queries, CancellationToken cancellationToken)
    {
        var product = await _productRespository.GetProductIdAsync(queries.Id);

        await _unitOfWork.Save(cancellationToken);

        return product;
    }
}
