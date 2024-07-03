using ChainSyncSolution.Application.Interfaces.IPersistence;
using ChainSyncSolution.Domain.Entities;
using ChainSyncSolution.Infrastructure.Common.Abstraction;
using ChainSyncSolution.Infrastructure.Context;

namespace ChainSyncSolution.Infrastructure.Common.Persistence;

public class InventoryRepository : BaseRepository<Inventory>, IinventoryRepository
{
    public InventoryRepository(ChainSyncDbContext _chainSyncDbContext)
        : base(_chainSyncDbContext)
    {

    }

    public async Task<Inventory> CreateInventory(Inventory inventory, CancellationToken cancellationToken)
    {
        await _chainSyncDbContext.Inventories.AddAsync(inventory);
        await _chainSyncDbContext.SaveChangesAsync(cancellationToken);

        return inventory;
    }

}
