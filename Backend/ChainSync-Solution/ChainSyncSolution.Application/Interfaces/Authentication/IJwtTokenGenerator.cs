using ChainSyncSolution.Domain.Entities;

namespace ChainSyncSolution.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
    string GenerateLoginToken(User user);
}
