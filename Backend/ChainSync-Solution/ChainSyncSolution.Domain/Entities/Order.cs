using ChainSyncSolution.Domain.BaseDomain;

namespace ChainSyncSolution.Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; } = new User();
    public DateTime OrderDate { get; set; }
    public float TotalAmount { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
