using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using ChainSyncSolution.Infrastructure.Common.Abstraction;
using ChainSyncSolution.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChainSyncSolution.Infrastructure.Common.Persistence;

public class ProductRepository : BaseRepository<Product>, IProductRespository
{
    public ProductRepository(ChainSyncDbContext _chainSyncDbContext)
        : base(_chainSyncDbContext)
    {

    }

    public async Task<Product> CreateProduct(Product product, CancellationToken cancellationToken)
    {
        await _chainSyncDbContext.Products.AddAsync(product);
        await _chainSyncDbContext.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        return await _chainSyncDbContext.Products
                                        .AsNoTracking()
                                        .ToListAsync();
    }

    public async Task<List<Product>> GetProductsBySupplierIdAsync(Guid supplierId)
    {
        return await _chainSyncDbContext.Products
                                        .Where(p => p.SupplierId == supplierId)
                                        .AsNoTracking()
                                        .ToListAsync();
    }

}
