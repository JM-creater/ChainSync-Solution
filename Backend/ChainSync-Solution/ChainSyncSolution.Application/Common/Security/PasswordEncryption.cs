using System.Security.Cryptography;
using System.Text;

namespace ChainSyncSolution.Application.Common.Security;

public class PasswordEncryption
{
    public static string HashPassword(string password)
    {
        var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }

    public static bool VerifyPassword(string hashedPassword, string storedHash)
    {
        var enteredHash = HashPassword(hashedPassword);
        return string.Equals(enteredHash, storedHash, StringComparison.Ordinal);
    }
}
