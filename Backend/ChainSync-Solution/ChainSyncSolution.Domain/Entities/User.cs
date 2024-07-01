using ChainSyncSolution.Domain.BaseDomain;
using ChainSyncSolution.Domain.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace ChainSyncSolution.Domain.Entities;

public class User : BaseEntity
{
    public User(
         Guid id,
         DateTimeOffset dateCreated,
         DateTimeOffset dateUpdated,
         DateTimeOffset? dateDeleted,
         string firstName,
         string lastName,
         string supplierId,
         string gender,
         string email,
         string phoneNumber,
         string password,
         string address,
         string companyName,
         string bizLicenseNumber,
         string profileImage,
         string document,
         bool isActive,
         bool isValidated,
         UserRole role)
         : base(id,
                dateCreated,
                dateUpdated,
                dateDeleted)
    {
        FirstName = firstName;
        LastName = lastName;
        SupplierId = supplierId;
        Gender = gender;
        Email = email;
        PhoneNumber = phoneNumber;
        Password = password;
        Address = address;
        CompanyName = companyName;
        BizLicenseNumber = bizLicenseNumber;
        ProfileImage = profileImage;
        Document = document;
        IsActive = isActive;
        IsValidated = isValidated;
        Role = role;
    }

    [StringLength(20)]
    public string? FirstName { get; private set; }

    [StringLength(20)]
    public string? LastName { get; private set; }

    [StringLength(10)]
    public string? SupplierId { get; private set; }

    [StringLength(30)]
    public string? Gender { get; private set; }

    [Required]
    [StringLength(30)]
    public string Email { get; private set; }

    [StringLength(11)]
    public string PhoneNumber { get; private set; }

    [Required]
    [StringLength(100)]
    public string Password { get; private set; }

    [StringLength(50)]
    public string Address { get; private set; }

    [StringLength(20)]
    public string? CompanyName { get; private set; }

    [StringLength(9)]
    public string? BizLicenseNumber { get; private set; }

    [DataType(DataType.ImageUrl)]
    public string? ProfileImage { get; private set; }

    [DataType(DataType.ImageUrl)]
    public string? Document { get; private set; }

    public bool IsActive { get; private set; }

    public bool IsValidated { get; private set; }

    public UserRole Role { get; private set; }

    public string? PasswordResetToken { get; private set; }

    public DateTime? ResetTokenExpires { get; private set; }

    public List<Order> Orders { get; private set; } = new List<Order>();
    public List<Product> Products { get; private set; } = new List<Product>();


    // Methods to set fields
    public void SetFirstName(string firstName)
    {
        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        LastName = lastName;
    }

    public void SetSupplierId(string supplierId)
    {
        SupplierId = supplierId;
    }

    public void SetGender(string gender)
    {
        Gender = gender;
    }

    public void SetEmail(string email)
    {
        Email = email;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public void SetPassword(string password)
    {
        Password = password;
    }

    public void SetAddress(string address)
    {
        Address = address;
    }

    public void SetCompanyName(string companyName)
    {
        CompanyName = companyName;
    }

    public void SetBizLicenseNumber(string bizLicenseNumber)
    {
        BizLicenseNumber = bizLicenseNumber;
    }

    public void SetProfileImage(string profileImage)
    {
        ProfileImage = profileImage;
    }

    public void SetDocument(string document)
    {
        Document = document;
    }

    public void SetIsActive(bool isActive)
    {
        IsActive = isActive;
    }

    public void SetIsValidated(bool isValidated)
    {
        IsValidated = isValidated;
    }

    public void SetRole(UserRole role)
    {
        Role = role;
    }

    public void SetPasswordResetToken(string? passwordResetToken)
    {
        PasswordResetToken = passwordResetToken; 
    }

    public void SetResetTokenExpires(DateTime? resetTokenExpires)
    {
        ResetTokenExpires = resetTokenExpires;
    }

    public void SetOrders(List<Order> orders)
    {
        Orders = orders;
    }

    public void SetProducts(List<Product> products)
    {
        Products = products;
    }
}