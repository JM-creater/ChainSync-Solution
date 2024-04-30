using ChainSyncSolution.Domain.BaseDomain;
using System.ComponentModel.DataAnnotations;

namespace ChainSyncSolution.Domain.Entities;

public class User : BaseEntity
{
    [StringLength(20)]
    public string FirstName { get; set; } = null!;
    [StringLength(20)]
    public string LastName { get; set; } = null!;
    [StringLength(30)]
    public string Email { get; set; } = null!;
    [StringLength(11)]
    public string PhoneNumber { get; set; } = null!;
    [StringLength(100)]
    public string Password { get; set; } = null!;
    public string? ProfileImage { get; set; }
}