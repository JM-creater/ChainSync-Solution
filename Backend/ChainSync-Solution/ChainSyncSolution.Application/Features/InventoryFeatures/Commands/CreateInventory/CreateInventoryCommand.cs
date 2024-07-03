using ChainSyncSolution.Contracts.Common.Inventory;
using MediatR;

namespace ChainSyncSolution.Application.Features.InventoryFeatures.Commands.CreateInventory;

public sealed record CreateInventoryCommand(
    Guid ProductId,
    int Quantity,
    DateTime LastRestockedDate) : IRequest<CreateInventoryRequest>;
