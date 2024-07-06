using AutoMapper;
using ChainSyncSolution.Application.Assets;
using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Products;
using MediatR;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Commands.UpdateProducts;

public class UpdateProductsCommandHandler : IRequestHandler<UpdateProductsByIdCommand, UpdateProductsRequest>
{
    private readonly IProductRespository _productRespository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductsCommandHandler(IProductRespository productRespository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRespository = productRespository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateProductsRequest> Handle(UpdateProductsByIdCommand command, CancellationToken cancellationToken)
    {
        var updateCommand = command.UpdateCommand;

        var product = await _productRespository.GetUpdateBySupplierIdAsync(command.SupplierId);

        if (product == null)
        {
            throw new CheckSupplierIdExistException(command.SupplierId);
        }

        if (updateCommand.ProductName != null)
        {
            product.SetName(updateCommand.ProductName);
        }
        if (updateCommand.Description != null)
        {
            product.SetDescription(updateCommand.Description);  
        }
        if (updateCommand.PhoneNumber != null)
        {
            product.SetPhoneNumber(updateCommand.PhoneNumber);  
        }
        if (updateCommand.Price != 0)
        {
            product.SetPrice(updateCommand.Price);
        }
        if (updateCommand.ProductImage != null)
        {
            string productImagePath = await new AssetConfiguration().SaveProductImages(updateCommand.ProductImage);
            product.SetProductImage(productImagePath);
        }
        if (updateCommand.QuantityOnHand != 0)
        {
            product.SetQuantityOnHand(updateCommand.QuantityOnHand);
        }

        product.SetDateCreated(DateTimeOffset.Now);

        await _productRespository.UpdateProductAsync(product.Id, cancellationToken);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<UpdateProductsRequest>(product);

    }
}
