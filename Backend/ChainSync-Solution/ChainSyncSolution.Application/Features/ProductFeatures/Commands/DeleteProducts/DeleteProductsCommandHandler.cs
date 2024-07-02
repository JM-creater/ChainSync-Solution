using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Commands.DeleteProducts;

public class DeleteProductsCommandHandler : IRequestHandler<DeleteProductsCommand, int>
{
    private readonly IProductRespository _productRespository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteProductsCommandHandler(IProductRespository productRespository, IUnitOfWork unitOfWork)
    {
        _productRespository = productRespository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(DeleteProductsCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRespository.GetProductIdAsync(command.Id);


        if (product == null)
        {
            throw new CheckIdExistException(command.Id);
        }

        return await _productRespository.DeleteProductAsync(product, cancellationToken);
    }
}
