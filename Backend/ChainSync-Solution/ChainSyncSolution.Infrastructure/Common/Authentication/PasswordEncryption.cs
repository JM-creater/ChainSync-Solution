using ChainSyncSolution.Application.Interfaces.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace ChainSyncSolution.Infrastructure.Common.Authentication;

public class PasswordEncryption : IPasswordEncryption
{
    public string HashPassword(string password)
    {
        var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }

    public bool VerifyPassword(string hashedPassword, string storedHash)
    {
        var enteredHash = HashPassword(hashedPassword);
        return string.Equals(enteredHash, storedHash, StringComparison.Ordinal);
    }
}
