namespace ChainSyncSolution.Application.Common.Exceptions.Base;

public abstract class BaseException : Exception
{
    public int StatusCode { get; set;  }

    protected BaseException(string messsage, int statusCode) : base(messsage)
    {
        StatusCode = statusCode;
    }
}
