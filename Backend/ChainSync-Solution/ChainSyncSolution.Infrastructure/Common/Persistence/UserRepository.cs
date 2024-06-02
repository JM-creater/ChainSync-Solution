using ChainSyncSolution.Application.Interfaces.Authentication;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Common.Enum;
using ChainSyncSolution.Domain.Entities;
using ChainSyncSolution.Infrastructure.Common.Abstraction;
using ChainSyncSolution.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ChainSyncSolution.Infrastructure.Common.Persistence;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly IPasswordEncryption _passwordEncryption;

    public UserRepository(ChainSyncDbContext _chainSyncDbContext, IPasswordEncryption passwordEncryption)
        : base(_chainSyncDbContext)
    {
        _passwordEncryption = passwordEncryption;
    }

    public async Task<User?> CheckPasswordLoginAsync(string email, string password)
    {
        var user = await _chainSyncDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            return null;
        }

        var isPasswordValid = _passwordEncryption.VerifyPassword(password, user.Password);
        return isPasswordValid ? user : null;
    }

    public async Task<User?> CheckEmailLoginAsync(string email)
    {
        return await _chainSyncDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetSupplierIdAsync(string id)
    {
        return await _chainSyncDbContext.Users.SingleOrDefaultAsync(u => u.SupplierId == id);
    }

    public async Task<User?> GetUserByPhoneNumberAsync(string phoneNumber)
    {
        return await _chainSyncDbContext.Users.SingleOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _chainSyncDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> RegisterAsync(User user, CancellationToken cancellationToken)
    {
        await _chainSyncDbContext.Users.AddAsync(user, cancellationToken);
        await _chainSyncDbContext.SaveChangesAsync(cancellationToken);
        return user;
    }

    public async Task<User> LoginAsync(User user, CancellationToken cancellationToken)
    {
        await _chainSyncDbContext.SaveChangesAsync(cancellationToken);
        return user;
    }
}
