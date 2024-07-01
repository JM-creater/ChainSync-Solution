namespace ChainSyncSolution.Contracts.Common.Users;

public sealed record ForgotPasswordRequest
{
    public string Email { get; init; } = null!;
}
