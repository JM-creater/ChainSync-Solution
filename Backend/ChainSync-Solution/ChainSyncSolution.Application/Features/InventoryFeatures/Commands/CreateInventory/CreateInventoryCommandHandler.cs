using AutoMapper;
using ChainSyncSolution.Application.Interfaces.ErrorControl;
using ChainSyncSolution.Application.Interfaces.IPersistence;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Inventory;
using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.InventoryFeatures.Commands.CreateInventory;

public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, CreateInventoryRequest>
{
    private readonly IProductRespository _productRespository;
    private readonly IinventoryRepository _inventoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IExceptionConfiguration _exceptionConfiguration;

    public CreateInventoryCommandHandler(
        IProductRespository productRespository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IExceptionConfiguration exceptionConfiguration,
        IinventoryRepository inventoryRepository)
    {
        _productRespository = productRespository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _exceptionConfiguration = exceptionConfiguration;
        _inventoryRepository = inventoryRepository;
    }

    public async Task<CreateInventoryRequest> Handle(
        CreateInventoryCommand command,
        CancellationToken cancellationToken)
    {
        await _exceptionConfiguration.CustomCreateInventoryValidator(command);

        var inventory = _mapper.Map<Inventory>(command);

        inventory.SetDateCreated(DateTimeOffset.Now);

        await _inventoryRepository.CreateInventory(inventory, cancellationToken);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<CreateInventoryRequest>(inventory);
    }
}
