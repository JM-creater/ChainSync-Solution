namespace ChainSyncSolution.Contracts.Common.Users;

public sealed record UpdateCustomerProfileRequest
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string PhoneNumber { get; init; } = null!;
    public string Password { get; init; } = null!;
    public string Gender { get; init; } = null!;
    public string CompanyName { get; init; } = null!;
    public string Address { get; init; } = null!;
}
