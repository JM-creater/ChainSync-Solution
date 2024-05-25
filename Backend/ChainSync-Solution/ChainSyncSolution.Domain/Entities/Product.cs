using ChainSyncSolution.Domain.BaseDomain;

namespace ChainSyncSolution.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Guid SupplierId { get; set; }
    public User Supplier { get; set; } = new User();    
    public string PhoneNumber { get; set; } = null!;
    public float Price { get; set; }
    public string ProfileImage { get; set; } = null!;
    public int QuantityOnHand { get; set; }
    public int ReorderLevel { get; set; }

    public Inventory Inventory { get; set; } = new Inventory();
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
