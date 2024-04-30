using ChainSyncSolution.Application.Interfaces.Abstraction;
using ChainSyncSolution.Domain.BaseDomain;
using ChainSyncSolution.Domain.Entities;
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

    public void Create(T entity)
    {
        _chainSyncDbContext.Add(entity);
    }

    public void Update(T entity)
    {
        _chainSyncDbContext.Update(entity);
    }

    public void Delete(T entity)
    {
        entity.DateCreated = DateTimeOffset.UtcNow;
        _chainSyncDbContext.Update(entity);
    }

    public Task<T> Get(Guid id, CancellationToken cancellationToken)
    {
        return _chainSyncDbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
        return _chainSyncDbContext.Set<T>().ToListAsync(cancellationToken);
    }
}
