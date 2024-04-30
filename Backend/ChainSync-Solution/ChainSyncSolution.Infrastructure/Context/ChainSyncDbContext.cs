using ChainSyncSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChainSyncSolution.Infrastructure.Context;

public class ChainSyncDbContext : DbContext
{
    public ChainSyncDbContext(DbContextOptions options) 
        : base(options)
    {

    }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChainSyncDbContext).Assembly);
    }
}
