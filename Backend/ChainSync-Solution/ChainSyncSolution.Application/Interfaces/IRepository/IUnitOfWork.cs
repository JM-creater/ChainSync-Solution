namespace ChainSyncSolution.Application.Interfaces.IRepository;

public interface IUnitOfWork
{
    Task Save(CancellationToken cancellationToken);
}
