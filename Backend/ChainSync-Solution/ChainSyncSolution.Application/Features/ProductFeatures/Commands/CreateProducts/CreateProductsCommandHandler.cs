using AutoMapper;
using ChainSyncSolution.Application.Assets;
using ChainSyncSolution.Application.Interfaces.ErrorControl;
using ChainSyncSolution.Application.Interfaces.IPersistence;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Products;
using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Commands.CreateProducts;

public class CreateProductsCommandHandler : IRequestHandler<CreateProductsCommand, CreateProductsRequest>
{
    private readonly IProductRespository _productRespository;
    private readonly IinventoryRepository _iinventoryRepository;
    private readonly IExceptionConfiguration _exceptionConfiguration;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProductsCommandHandler(IProductRespository productRespository, IExceptionConfiguration exceptionConfiguration, IMapper mapper, IUnitOfWork unitOfWork, IinventoryRepository iinventoryRepository)
    {
        _productRespository = productRespository;
        _exceptionConfiguration = exceptionConfiguration;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _iinventoryRepository = iinventoryRepository;
    }

    public async Task<CreateProductsRequest> Handle(CreateProductsCommand command, CancellationToken cancellationToken)
    {
        await _exceptionConfiguration.CustomCreateProduct(command);

        var product = _mapper.Map<Product>(command);

        if (command.ProductImage != null)
        {
            string productImagePath = await new AssetConfiguration().SaveProductImages(command.ProductImage);
            product.SetProductImage(productImagePath);
        }

        product.SetDateCreated(DateTimeOffset.Now);
        product.SetIsActive(true);

        await _productRespository.CreateProduct(product, cancellationToken);

        var inventory = new Inventory(
            id: Guid.NewGuid(),
            dateCreated: DateTimeOffset.Now,
            dateUpdated: DateTimeOffset.Now,
            dateDeleted: null,
            productId: product.Id,
            quantity: command.QuantityOnHand,
            lastRestockedDate: DateTime.Now 
        );

        await _iinventoryRepository.CreateInventory(inventory, cancellationToken);

        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateProductsRequest>(product); 
    }
}
