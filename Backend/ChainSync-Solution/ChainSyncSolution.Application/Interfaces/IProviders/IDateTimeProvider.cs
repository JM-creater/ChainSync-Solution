namespace ChainSyncSolution.Application.Interfaces.Providers;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
