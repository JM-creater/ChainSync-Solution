using ChainSyncSolution.Domain.BaseDomain;

namespace ChainSyncSolution.Domain.Entities;

public class OrderItem : BaseEntity
{
    public OrderItem(
       Guid id,
       DateTimeOffset dateCreated,
       DateTimeOffset dateUpdated,
       DateTimeOffset? dateDeleted,
       Guid orderId,
       Guid productId,
       int quantity,
       float unitPrice,
       float totalPrice)
       : base(id,
              dateCreated,
              dateUpdated,
              dateDeleted)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
        TotalPrice = totalPrice;
    }

    public Guid OrderId { get; private set; }
    public virtual Order Order { get; private set; } = null!;
    public Guid ProductId { get; private set; }
    public virtual Product Product { get; private set; } = null!;
    public int Quantity { get; private set; }
    public float UnitPrice { get; private set; }
    public float TotalPrice { get; private set; }

    // Methods to set fields
    public void SetOrderId(Guid orderId)
    {
        OrderId = orderId;
    }

    public void SetOrder(Order order)
    {
        Order = order;
    }

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

    public void SetUnitPrice(float unitPrice)
    {
        UnitPrice = unitPrice;
    }

    public void SetTotalPrice(float totalPrice)
    {
        TotalPrice = totalPrice;
    }
}
