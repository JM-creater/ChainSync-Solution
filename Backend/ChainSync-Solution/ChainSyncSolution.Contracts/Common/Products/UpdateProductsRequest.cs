namespace ChainSyncSolution.Contracts.Common.Products;

public sealed record UpdateProductsRequest
{
    public string ProductName { get; init; } = null!;
    public string Description { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public float Price { get; init; }
    public string? ProductImage { get; init; }
    public int QuantityOnHand { get; init; }
}
