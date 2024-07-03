namespace ChainSyncSolution.Contracts.Common.Inventory;

public sealed record CreateInventoryRequest
{
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public DateTime LastRestockedDate { get; init; }
}
