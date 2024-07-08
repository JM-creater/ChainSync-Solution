using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace ChainSyncSolution.Infrastructure.Connection;

public class InterceptorSettings : DbCommandInterceptor
{
    private int _slowQueryThreshold = 200;

    public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
    {
        if (eventData.Duration.TotalMilliseconds > _slowQueryThreshold)
        {
            Console.WriteLine($"Slow query ({eventData.Duration.TotalMilliseconds} ms): {command.CommandText}");
        }

        return base.ReaderExecuted(command, eventData, result);
    }

}
