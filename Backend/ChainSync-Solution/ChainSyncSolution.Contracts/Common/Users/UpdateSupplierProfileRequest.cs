using ChainSyncSolution.Domain.Common.Enum;

namespace ChainSyncSolution.Contracts.Common.Users;

public sealed record UpdateSupplierProfileRequest
{
    public string? SupplierId { get; init; }
    public string Email { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string CompanyName { get; init; } = null!;
    public string Address { get; init; } = null!;
    public string? Document { get; init; }
    public string? BizLicenseNumber { get; init; }
    public string Token { get; init; } = null!;
    public UserRole Role { get; init; }
}
