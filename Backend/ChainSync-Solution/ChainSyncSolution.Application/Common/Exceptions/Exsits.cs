using ChainSyncSolution.Application.Common.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace ChainSyncSolution.Application.Common.Exceptions;

public class PhoneNumberExistsException : BaseException
{
    public PhoneNumberExistsException(string phoneNumber)
        : base($"The phone number {phoneNumber} is already registered.", StatusCodes.Status409Conflict)
    {
    }
}

public class EmailExistsException : BaseException
{
    public EmailExistsException(string email)
        : base($"The email {email} is already registered.", StatusCodes.Status409Conflict)
    {

    }
}

public class BizLicenseNumberExistsException : BaseException
{
    public BizLicenseNumberExistsException(string licenseNumber)
        : base($"The business license number {licenseNumber} is already registered.", StatusCodes.Status409Conflict)
    {

    }
}

public class CheckIdExistException : BaseException
{
    public CheckIdExistException(Guid id)
        : base($"The id {id} you entered does not exists.", StatusCodes.Status400BadRequest)
    {

    }
}

public class  CheckSupplierIdExistException : BaseException
{
    public CheckSupplierIdExistException(string id)
        : base($"The id {id} you entered does not exists.", StatusCodes.Status400BadRequest)
    {

    }
}

public class CheckTokenExistsException : BaseException
{
    public CheckTokenExistsException(string token)
        : base($"The token {token} does not exists.", StatusCodes.Status400BadRequest)
    {

    }
}

