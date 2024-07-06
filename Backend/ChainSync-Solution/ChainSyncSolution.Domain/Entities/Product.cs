using ChainSyncSolution.Domain.BaseDomain;
using System.ComponentModel.DataAnnotations;

namespace ChainSyncSolution.Domain.Entities;

public class Product : BaseEntity
{
    public Product(
       Guid id,
       DateTimeOffset dateCreated,
       DateTimeOffset dateUpdated,
       DateTimeOffset? dateDeleted,
       string productName,
       string description,
       string supplierId,
       string phoneNumber,
       float price,
       string productImage,
       int quantityOnHand,
       bool isActive
       )
       : base(
           id,
           dateCreated,
           dateUpdated,
           dateDeleted)
    {
        ProductName = productName;
        Description = description;
        SupplierId = supplierId;
        PhoneNumber = phoneNumber;
        Price = price;
        ProductImage = productImage;
        QuantityOnHand = quantityOnHand;
        IsActive = isActive;
    }

    [Required]
    [StringLength(20)]
    public string ProductName { get; private set; } = null!;
    [Required]
    [StringLength(100)]
    public string Description { get; private set; } = null!;
    public string SupplierId { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public float Price { get; private set; }
    public string? ProductImage { get; private set; }
    public int QuantityOnHand { get; private set; }
    public bool IsActive { get; private set; }

    public Inventory Inventory { get; private set; } = null!;
    public List<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

    // Methods to set fields
    public void SetName(string productName)
    {
        ProductName = productName;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetSupplierId(string supplierId)
    {
        SupplierId = supplierId;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public void SetPrice(float price)
    {
        Price = price;
    }

    public void SetProductImage(string productImage)
    {
        ProductImage = productImage;
    }

    public void SetQuantityOnHand(int quantityOnHand)
    {
        QuantityOnHand = quantityOnHand;
    }

    public void SetIsActive(bool isActive)
    {
        IsActive = isActive;
    }

    public void SetInventory(Inventory inventory)
    {
        Inventory = inventory;
    }

    public void SetOrderItems(List<OrderItem> orderItems)
    {
        OrderItems = orderItems ?? new List<OrderItem>();
    }
}
