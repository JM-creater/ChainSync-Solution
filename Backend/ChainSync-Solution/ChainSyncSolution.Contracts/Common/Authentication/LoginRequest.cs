namespace ChainSyncSolution.Contracts.Common.Authentication;

public sealed record LoginRequest
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Token { get; set; } = null!;
}
