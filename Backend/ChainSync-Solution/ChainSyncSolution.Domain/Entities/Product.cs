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
       string name,
       string description,
       Guid supplierId,
       string phoneNumber,
       float price,
       string profileImage,
       int quantityOnHand,
       int reorderLevel
       )
       : base(
           id,
           dateCreated,
           dateUpdated,
           dateDeleted)
    {
        Name = name;
        Description = description;
        SupplierId = supplierId;
        PhoneNumber = phoneNumber;
        Price = price;
        ProfileImage = profileImage;
        QuantityOnHand = quantityOnHand;
        ReorderLevel = reorderLevel;
    }

    [Required]
    [StringLength(20)]
    public string Name { get; private set; } = null!;
    [Required]
    [StringLength(100)]
    public string Description { get; private set; } = null!;
    public Guid SupplierId { get; private set; }
    public User Supplier { get; private set; } = null!;
    public string PhoneNumber { get; private set; } = null!;
    public float Price { get; private set; }
    public string ProfileImage { get; private set; } = null!;
    public int QuantityOnHand { get; private set; }
    public int ReorderLevel { get; private set; }

    public Inventory Inventory { get; private set; } = null!;
    public List<OrderItem> OrderItems { get; private set; } = new List<OrderItem>();

    // Methods to set fields
    public void SetName(string name)
    {
        Name = name;
    }

    public void SetDescription(string description)
    {
        Description = description;
    }

    public void SetSupplierId(Guid supplierId)
    {
        SupplierId = supplierId;
    }

    public void SetSupplier(User supplier)
    {
        Supplier = supplier;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public void SetPrice(float price)
    {
        Price = price;
    }

    public void SetProfileImage(string profileImage)
    {
        ProfileImage = profileImage;
    }

    public void SetQuantityOnHand(int quantityOnHand)
    {
        QuantityOnHand = quantityOnHand;
    }

    public void SetReorderLevel(int reorderLevel)
    {
        ReorderLevel = reorderLevel;
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
