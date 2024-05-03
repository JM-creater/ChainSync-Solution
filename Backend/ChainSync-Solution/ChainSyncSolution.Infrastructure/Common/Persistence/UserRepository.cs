using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using ChainSyncSolution.Infrastructure.Common.Abstraction;
using ChainSyncSolution.Infrastructure.Context;

namespace ChainSyncSolution.Infrastructure.Common.Persistence;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(ChainSyncDbContext _chainSyncDbContext) : base(_chainSyncDbContext)
    {

    }

    public User? GetUserByEmail(string email)
    {
        return _chainSyncDbContext.Users.SingleOrDefault(u => u.Email == email);
    }

    public async Task<User> Register(User user)
    {
        await _chainSyncDbContext.Users.AddAsync(user);

        return user;
    }

    public async Task<User> Login(User user)
    {
        await _chainSyncDbContext.SaveChangesAsync();

        return user;
    }
}
