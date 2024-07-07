namespace ChainSyncSolution.Contracts.Common.Products;

public sealed record CreateProductsRequest
{
    public string ProductName { get; init; } = null!;
    public string Description { get; init; } = null!;
    public string SupplierId { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public float Price { get; init; }
    public string? ProductImage { get; init; }
    public int QuantityOnHand { get; init; }
    public bool IsActive { get; init; }
}
