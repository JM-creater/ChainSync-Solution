using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.Search.SearchProducts;

public class SearchProductsCommandHandler : IRequestHandler<SearchProductsCommand, List<Product>>
{
    private readonly IProductRespository _productRespository;

    public SearchProductsCommandHandler(IProductRespository productRespository)
    {
        _productRespository = productRespository;
    }

    public async Task<List<Product>> Handle(SearchProductsCommand request, CancellationToken cancellationToken)
    {
        var query = _productRespository.Query();

        if (!string.IsNullOrEmpty(request.ProductName))
        {
            query = query.Where(p => p.ProductName.Contains(request.ProductName));
        }

        return await Task.FromResult(query.ToList());
    }
}
