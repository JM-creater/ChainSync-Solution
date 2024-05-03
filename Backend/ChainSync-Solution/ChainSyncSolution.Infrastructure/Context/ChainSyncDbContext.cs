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
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Inventory> Inventories => Set<Inventory>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChainSyncDbContext).Assembly);
    }
}
