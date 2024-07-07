using ChainSyncSolution.Domain.Entities;

namespace ChainSyncSolution.Application.Interfaces.Persistence;

public interface IProductRespository
{
    Task<Product> CreateProduct(Product product, CancellationToken cancellationToken);
    Task<List<Product>> GetProductsAsync();
    Task<List<Product>> GetProductsBySupplierIdAsync(string supplierId);
    Task<Product> GetProductIdAsync(Guid id);
    Task<Product?> GetUpdateBySupplierIdAsync(string supplierId);
    Task<Product> UpdateProductAsync(Guid id, CancellationToken cancellationToken);
    Task<int> DeleteProductAsync(Product product, CancellationToken cancellationToken);
    IQueryable<Product> Query();
}
