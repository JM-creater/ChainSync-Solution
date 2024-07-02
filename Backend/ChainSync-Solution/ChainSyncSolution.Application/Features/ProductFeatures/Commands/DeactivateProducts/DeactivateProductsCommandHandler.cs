using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using MediatR;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Commands.DeactivateProducts;

public class DeactivateProductsCommandHandler : IRequestHandler<DeactivateProductsCommand, bool>
{
    private readonly IProductRespository _productRespository;
    private readonly IUnitOfWork _unitOfWork;

    public DeactivateProductsCommandHandler(IProductRespository productRespository, IUnitOfWork unitOfWork)
    {
        _productRespository = productRespository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeactivateProductsCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRespository.GetProductIdAsync(command.Id);

        if (product is null)
        {
            throw new CheckIdExistException(command.Id);
        }

        product.SetIsActive(false);
        product.SetDateUpdated(DateTimeOffset.Now);

        await _productRespository.UpdateProductAsync(product.Id, cancellationToken);

        return true; 
    }
}
