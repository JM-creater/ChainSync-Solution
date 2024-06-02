namespace ChainSyncSolution.Application.Common.Behavior.Common;

public class BadRequestException : Exception
{
    public string[]? Errors { get; set; }

    public BadRequestException(string message) 
        : base(message)
    {

    }

    public BadRequestException(string[] errors) : base("Multiple errors occurred. See error details.")
    {
        Errors = errors;
    }
}
