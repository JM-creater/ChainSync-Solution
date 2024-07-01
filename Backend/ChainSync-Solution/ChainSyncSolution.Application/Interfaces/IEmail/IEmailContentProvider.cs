namespace ChainSyncSolution.Application.Interfaces.IEmail;

public interface IEmailContentProvider
{
    Task SendPasswordForgotEmail(string email, string token);
}
