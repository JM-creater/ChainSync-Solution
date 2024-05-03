using ChainSyncSolution.Domain.BaseDomain;

namespace ChainSyncSolution.Domain.Entities;

public class Inventory : BaseEntity
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; } = new Product();
    public int Quantity { get; set; }
    public DateTime LastRestockedDate { get; set; }
}
