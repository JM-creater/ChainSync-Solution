using ChainSyncSolution.Domain.BaseDomain;

namespace ChainSyncSolution.Application.Interfaces.Abstraction;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
    Task<T> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
}
