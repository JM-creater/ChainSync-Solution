using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using ChainSyncSolution.Infrastructure.Common.Abstraction;
using ChainSyncSolution.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChainSyncSolution.Infrastructure.Common.Persistence;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ChainSyncDbContext _chainSyncDbContext) : base(_chainSyncDbContext)
    {
    }

    public async Task<User> Register(User user)
    {
        await _chainSyncDbContext.Users.AddAsync(user);

        return user;
    }

    public Task<User> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return _chainSyncDbContext.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }
}
