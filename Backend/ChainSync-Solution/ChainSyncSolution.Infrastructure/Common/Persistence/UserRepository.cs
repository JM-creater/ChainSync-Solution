﻿using ChainSyncSolution.Application.Common.Security;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using ChainSyncSolution.Infrastructure.Common.Abstraction;
using ChainSyncSolution.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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

    public async Task<int> UpdateCustomerProfile(Guid id, User user, CancellationToken cancellationToken)
    {
        var userExisting = await _chainSyncDbContext.Users.Where(u => u.Id == id).FirstOrDefaultAsync();

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
}
