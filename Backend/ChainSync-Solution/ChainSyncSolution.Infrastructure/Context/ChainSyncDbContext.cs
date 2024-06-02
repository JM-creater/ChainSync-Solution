using ChainSyncSolution.Domain.Common.Enum;
using ChainSyncSolution.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChainSyncSolution.Infrastructure.Context;

public class ChainSyncDbContext : DbContext
{
    public ChainSyncDbContext(DbContextOptions options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users => Set<User>();
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


        modelBuilder.Entity<User>().HasData(
             new User(
                 id: Guid.NewGuid(),
                 dateCreated: DateTimeOffset.UtcNow,
                 dateUpdated: DateTimeOffset.UtcNow,
                 dateDeleted: null,
                 firstName: "Joseph Martin",
                 lastName: "Garado",
                 supplierId: string.Empty,
                 gender: string.Empty,
                 email: "garado@gmail.com",
                 phoneNumber: "12345678901",
                 password: "12345",
                 address: string.Empty,
                 companyName: string.Empty,
                 bizLicenseNumber: string.Empty,
                 profileImage: "PathImages\\Profile\\Joseph Martin T. Garado.png",
                 document: string.Empty,
                 isActive: true,
                 isValidated: true,
                 role: UserRole.Admin
             )
        );
    }
}
