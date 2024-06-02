namespace ChainSyncSolution.Application.Interfaces.Authentication;

public interface IPasswordEncryption
{
    string HashPassword(string password);
    bool VerifyPassword(string hashedPassword, string storedHash);
}
