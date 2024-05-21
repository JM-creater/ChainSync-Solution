namespace ChainSyncSolution.Application.Common.Exceptions;

public class CheckEmailLoginException : Exception
{
    public CheckEmailLoginException(string email)
        : base($"The email {email} you entered is invalid.")
    {

    }
}
