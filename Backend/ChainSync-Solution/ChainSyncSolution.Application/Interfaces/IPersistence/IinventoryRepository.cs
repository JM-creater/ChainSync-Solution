using ChainSyncSolution.Domain.Entities;

namespace ChainSyncSolution.Application.Interfaces.IPersistence;

public interface IinventoryRepository
{
    Task<Inventory> CreateInventory(Inventory inventory, CancellationToken cancellationToken);
}
