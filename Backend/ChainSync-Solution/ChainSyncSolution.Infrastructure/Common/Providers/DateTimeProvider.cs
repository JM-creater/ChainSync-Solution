using ChainSyncSolution.Application.Interfaces.Providers;

namespace ChainSyncSolution.Infrastructure.Common.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
