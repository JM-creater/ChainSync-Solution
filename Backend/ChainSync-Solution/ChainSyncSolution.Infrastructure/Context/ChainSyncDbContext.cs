using ChainSyncSolution.Domain.Common.Enum;
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
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Joseph Martin",
                LastName = "Garado",
                Email = "garado@gmail.com",
                PhoneNumber = "12345678901",
                Password = "12345",
                CompanyName = string.Empty,
                ProfileImage = "PathImages\\Profile\\Joseph Martin T. Garado.png",
                IsActive = true,
                IsValidated = true,
                Role = UserRole.Admin
            }
        );
    }
}
