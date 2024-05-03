using ChainSyncSolution.Domain.BaseDomain;

namespace ChainSyncSolution.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = new Order();
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = new Product();
    public int Quantity { get; set; }
    public float UnitPrice { get; set; }
    public float TotalPrice { get; set; }
}
