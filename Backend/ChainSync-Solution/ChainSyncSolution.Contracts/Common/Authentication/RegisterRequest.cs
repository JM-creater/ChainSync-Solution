using ChainSyncSolution.Domain.Common.Enum;

namespace ChainSyncSolution.Contracts.Common.Authentication;

public sealed record RegisterRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Token { get; set; } = null!;
    public UserRole Role { get; set; } 
}
