namespace ChainSyncSolution.Domain.Errors;

public class EmailExistsException : Exception
{
    public EmailExistsException(string email) 
        : base($"The email {email} is already registered in the system.")
    {

    }
}
