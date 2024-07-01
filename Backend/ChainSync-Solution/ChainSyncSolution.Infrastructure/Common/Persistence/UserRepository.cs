using ChainSyncSolution.Application.Common.Security;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using ChainSyncSolution.Domain.Common.Enum;
using ChainSyncSolution.Infrastructure.Common.Abstraction;
using ChainSyncSolution.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using ChainSyncSolution.Application.Common.Exceptions;

namespace ChainSyncSolution.Infrastructure.Common.Persistence;

public class UserRepository : BaseRepository<User>, IUserRepository
{

    public UserRepository(ChainSyncDbContext _chainSyncDbContext)
        : base(_chainSyncDbContext)
    {

    }

    public async Task<User?> CheckPasswordLoginAsync(string email, string password)
    {
        var user = await _chainSyncDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            return null;
        }

        var isPasswordValid = PasswordEncryption.VerifyPassword(password, user.Password);
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

    public async Task<List<User>> GetUsersAsync()
       => await _chainSyncDbContext.Users
                                   .AsNoTracking()
                                   .ToListAsync();

    public async Task<User?> GetUsersByIdAsync(Guid id)
    {
       return await _chainSyncDbContext.Users.Where(u => u.Id == id)
                                             .FirstOrDefaultAsync();
    }

    public async Task<User?> GetUsersByEmailAsync(string email)
    {
        return await _chainSyncDbContext.Users.Where(u => u.Email == email)
                                              .FirstOrDefaultAsync();
    }

    public async Task<int> UpdateProfileAsync(User user, CancellationToken cancellationToken)
    {
        _chainSyncDbContext.Users.Update(user);
        return await _chainSyncDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteUsersAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _chainSyncDbContext.Users
                                            .Where(u => u.Id == id)
                                            .FirstOrDefaultAsync();
        _chainSyncDbContext.Users.Remove(user);
        return await _chainSyncDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<User>> GetSuppliersAsync()
    {
        return await _chainSyncDbContext.Users.Where(u => u.Role == UserRole.Supplier)
                                              .ToListAsync();
    }

    public async Task<List<User>> GetCustomersAsync()
    {
        return await _chainSyncDbContext.Users.Where(u => u.Role == UserRole.Customer)
                                              .ToListAsync();
    }

    public async Task<User> UpdateCustomerValidationAsync(Guid id)
    {
        var user = await _chainSyncDbContext.Users.Where(u => u.Id == id && 
                                                              u.Role == UserRole.Customer)
                                                  .FirstOrDefaultAsync();

        if (user is null) 
        {
            throw new CheckCustomerValidationException(id);
        }

        _chainSyncDbContext.Users.Update(user);

        return user;
    }

    public async Task<User> UpdateSupplierValidationAsync(Guid id)
    {
        var user = await _chainSyncDbContext.Users.Where(u => u.Id == id &&
                                                              u.Role == UserRole.Supplier)
                                                  .FirstOrDefaultAsync();

        if (user is null)
        {
            throw new CheckSupplierValidationException(id);
        }

        _chainSyncDbContext.Users.Update(user);

        return user;
    }

    public async Task<User> UpdatePasswordAsync(User user)
    {
        _chainSyncDbContext.Users.Update(user);
        await _chainSyncDbContext.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetPasswordTokenAsync(string token)
    {
        var user = await _chainSyncDbContext.Users.Where(u => u.PasswordResetToken == token)
                                                  .FirstOrDefaultAsync();

        if (user is null)
        {
            throw new CheckTokenExistsException(token);
        }

        return user;
    }
}
