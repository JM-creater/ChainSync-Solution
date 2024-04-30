using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Infrastructure.Context;

namespace ChainSyncSolution.Infrastructure.Common.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ChainSyncDbContext _chainSyncDbContext;

    public UnitOfWork(ChainSyncDbContext chainSyncDbContext1)
    {
        _chainSyncDbContext = chainSyncDbContext1;
    }
    public Task Save(CancellationToken cancellationToken)
    {
        return _chainSyncDbContext.SaveChangesAsync(cancellationToken);
    }
}
