using ChainSyncSolution.Domain.Entities;

namespace ChainSyncSolution.Application.Interfaces.Persistence;

public interface IProductRespository
{
    Task<Product> CreateProduct(Product product, CancellationToken cancellationToken);
    Task<List<Product>> GetProductsAsync();
    Task<List<Product>> GetProductsBySupplierIdAsync(Guid supplierId);
    Task<Product> GetProductIdAsync(Guid id);
    Task<Product> UpdateProductAsync(Guid id, CancellationToken cancellationToken);
}
