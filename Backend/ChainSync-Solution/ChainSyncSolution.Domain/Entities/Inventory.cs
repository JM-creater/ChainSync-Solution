using ChainSyncSolution.Domain.BaseDomain;

namespace ChainSyncSolution.Domain.Entities;

public class Inventory : BaseEntity
{
    public Inventory(Guid id,
        DateTimeOffset dateCreated,
        DateTimeOffset dateUpdated,
        DateTimeOffset? dateDeleted,
        Guid productId,
        int quantity,
        DateTime lastRestockedDate)
        : base(
            id,
            dateCreated,
            dateUpdated,
            dateDeleted)
    {
        ProductId = productId;
        Quantity = quantity;
        LastRestockedDate = lastRestockedDate;
    }

    public Guid ProductId { get; private set; }
    public virtual Product Product { get; private set; } = null!;
    public int Quantity { get; private set; }
    public DateTime LastRestockedDate { get; private set; }

    // Methods to set fields
    public void SetProductId(Guid productId)
    {
        ProductId = productId;
    }

    public void SetProduct(Product product)
    {
        Product = product;
    }

    public void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }

    public void SetLastRestockedDate(DateTime lastRestockedDate)
    {
        LastRestockedDate = lastRestockedDate;
    }
}
