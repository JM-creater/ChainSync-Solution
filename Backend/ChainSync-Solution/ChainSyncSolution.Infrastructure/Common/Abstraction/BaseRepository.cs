using ChainSyncSolution.Application.Interfaces.Abstraction;
using ChainSyncSolution.Domain.BaseDomain;
using ChainSyncSolution.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChainSyncSolution.Infrastructure.Common.Abstraction;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ChainSyncDbContext _chainSyncDbContext;

    public BaseRepository(ChainSyncDbContext chainSyncDbContext)
    {
        _chainSyncDbContext = chainSyncDbContext;
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await _chainSyncDbContext.AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _chainSyncDbContext.Update(entity);
        await _chainSyncDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        entity.SetDateDeleted(DateTimeOffset.UtcNow);
        _chainSyncDbContext.Update(entity);
        await _chainSyncDbContext.SaveChangesAsync(cancellationToken);
    }

    public Task<T> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return _chainSyncDbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _chainSyncDbContext.Set<T>().ToListAsync(cancellationToken);
    }
}
