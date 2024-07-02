namespace ChainSyncSolution.Contracts.Common.Products;

public sealed record CreateProductsRequest
{
    public string ProductName { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public Guid SupplierId { get; private set; }
    public string PhoneNumber { get; private set; } = null!;
    public float Price { get; private set; }
    public string? ProductImage { get; private set; }
    public int QuantityOnHand { get; private set; }
}
