using ChainSyncSolution.Application.Common.Exceptions;
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

    public async Task<Product> GetProductIdAsync(Guid id)
    {
        return await _chainSyncDbContext.Products
                                        .Where(p => p.Id == id)
                                        .FirstOrDefaultAsync();
    }

    public async Task<List<Product>> GetProductsBySupplierIdAsync(string supplierId)
    {
        return await _chainSyncDbContext.Products
                                        .Where(p => p.SupplierId == supplierId)
                                        .AsNoTracking()
                                        .ToListAsync();
    }

    public async Task<Product> UpdateProductAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _chainSyncDbContext.Products
                                               .Where(p => p.Id == id)
                                               .FirstOrDefaultAsync();

        if (product is null)
        {
            throw new CheckIdExistException(id);
        }

         _chainSyncDbContext.Products.Update(product);
        await _chainSyncDbContext.SaveChangesAsync(cancellationToken);

        return product;
    }

    public async Task<int> DeleteProductAsync(Product product, CancellationToken cancellationToken)
    {
        _chainSyncDbContext.Products.Remove(product);
        return await _chainSyncDbContext.SaveChangesAsync(cancellationToken);
    }

}
