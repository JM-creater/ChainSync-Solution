using ChainSyncSolution.Domain.BaseDomain;
using ChainSyncSolution.Domain.Common.Enum;

namespace ChainSyncSolution.Domain.Entities;

public class Order : BaseEntity
{
    public Order(
       Guid id,
       DateTimeOffset dateCreated,
       DateTimeOffset dateUpdated,
       DateTimeOffset? dateDeleted,
       Guid userId,
       DateTime orderDate,
       float totalAmount,
       OrderStatus orderStatus,
       PaymentStatus paymentStatus)
     : base(id,
            dateCreated,
            dateUpdated,
            dateDeleted)
    {
        UserId = userId;
        OrderDate = orderDate;
        TotalAmount = totalAmount;
        PaymentStatus = paymentStatus;
        OrderStatus = orderStatus;
        OrderItems = new List<OrderItem>();
    }

    public Guid UserId { get; private set; }
    public virtual User User { get; private set; } = null!;
    public DateTime OrderDate { get; private set; }
    public float TotalAmount { get; private set; }
    public PaymentStatus PaymentStatus { get; private set; }
    public OrderStatus OrderStatus { get; private set; }
    public List<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

    // Methods to set fields
    public void SetUserId(Guid userId)
    {
        UserId = userId;
    }

    public void SetUser(User user)
    {
        User = user;
    }

    public void SetOrderDate(DateTime orderDate)
    {
        OrderDate = orderDate;
    }

    public void SetTotalAmount(float totalAmount)
    {
        TotalAmount = totalAmount;
    }

    public void SetPaymentStatus(PaymentStatus paymentStatus)
    {
        PaymentStatus = paymentStatus;
    }

    public void SetOrderStatus(OrderStatus orderStatus)
    {
        OrderStatus = orderStatus;
    }

    public void SetOrderItems(List<OrderItem> orderItems)
    {
        OrderItems = orderItems ?? new List<OrderItem>();
    }
}
