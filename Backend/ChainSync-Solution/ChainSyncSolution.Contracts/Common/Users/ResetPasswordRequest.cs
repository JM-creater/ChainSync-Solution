namespace ChainSyncSolution.Contracts.Common.Users;

public class ResetPasswordRequest
{
    public string Token { get; init; } = null!;
    public string NewPassword { get; init; } = null!;
}
