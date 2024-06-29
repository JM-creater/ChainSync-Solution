using ChainSyncSolution.Application.Interfaces.Abstraction;
using ChainSyncSolution.Domain.Entities;

namespace ChainSyncSolution.Application.Interfaces.Persistence;

public interface IUserRepository : IBaseRepository<User>
{
    Task<List<User>> GetUsersAsync();
    Task<User?> CheckPasswordLoginAsync(string email, string password);
    Task<User?> CheckEmailLoginAsync(string email);
    Task<User?> GetUserByPhoneNumberAsync(string phoneNumber);
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetSupplierIdAsync(string id);
    Task<User> RegisterAsync(User user, CancellationToken cancellationToken);
    Task<User> LoginAsync(User user, CancellationToken cancellationToken);
}
