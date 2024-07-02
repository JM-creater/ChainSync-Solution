using ChainSyncSolution.Application.Common.Exceptions.Base;
using Microsoft.AspNetCore.Http;

namespace ChainSyncSolution.Application.Common.Exceptions;

#region Image 
public class InvalidImageProvideException : BaseException
{
    public InvalidImageProvideException(IFormFile? image)
        : base($"Invalid {image} file provided.", StatusCodes.Status400BadRequest)
    {

    }
}
#endregion

#region Login

public class CheckPasswordLoginException : BaseException
{
    public CheckPasswordLoginException(string password)
        : base($"The password {password} you entered is invalid.", StatusCodes.Status400BadRequest)
    {

    }
}


public class CheckEmailLoginException : BaseException
{
    public CheckEmailLoginException(string email)
        : base($"The email {email} you entered is invalid.", StatusCodes.Status400BadRequest)
    {

    }
}

public class EmailPasswordMismatchException : BaseException
{
    public EmailPasswordMismatchException(string email, string password)
        : base($"The email {email} does not match the password {password}.", StatusCodes.Status409Conflict)
    {

    }
}
#endregion 

#region Register
public class FirstNameEmptyException : BaseException
{
    public FirstNameEmptyException()
        : base("First name cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class LastNameEmptyException : BaseException
{
    public LastNameEmptyException()
        : base("Last name cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class PhoneNumberEmptyException : BaseException
{
    public PhoneNumberEmptyException()
        : base("Phone Number cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class GenderEmptyException : BaseException
{
    public GenderEmptyException()
        : base("Gender cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class EmailEmptyException : BaseException
{
    public EmailEmptyException()
        : base("Email cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class PasswordEmptyException : BaseException
{
    public PasswordEmptyException()
        : base("Password cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class AddressEmptyException : BaseException
{
    public AddressEmptyException()
        : base("Address cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class CompanyNameEmptyException : BaseException
{
    public CompanyNameEmptyException()
        : base("Company name cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class BizLicenseNumberEmptyException : BaseException
{
    public BizLicenseNumberEmptyException()
        : base("Business license number name cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class SupplierIdEmptyException : BaseException
{
    public SupplierIdEmptyException()
        : base("Supplier id cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}
#endregion

#region Validate

public class CheckCustomerValidationException : BaseException
{
    public CheckCustomerValidationException(Guid id)
        : base($"The Id {id} you entered is not a customer.", StatusCodes.Status400BadRequest)
    {

    }
}

public class CheckSupplierValidationException : BaseException
{
    public CheckSupplierValidationException(Guid id)
        : base($"The Id {id} you entered is not a supplier.", StatusCodes.Status400BadRequest)
    {

    }
}
#endregion

#region Product

public class ProductNameEmptyException : BaseException
{
    public ProductNameEmptyException()
        : base("Product name cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class DescriptionEmptyException : BaseException
{
    public DescriptionEmptyException()
        : base("Description cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class SupplierIdProductEmptyException : BaseException
{
    public SupplierIdProductEmptyException()
        : base("Supplier Id cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class SupplierIDProductEmptyException : BaseException
{
    public SupplierIDProductEmptyException()
        : base("Supplier Id cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class PhoneNumberProductEmptyException : BaseException
{
    public PhoneNumberProductEmptyException()
        : base("Phone number cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class PriceEmptyException : BaseException
{
    public PriceEmptyException()
        : base("Price cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class ProductImageEmptyException : BaseException
{
    public ProductImageEmptyException()
        : base("Product Image cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}

public class QuantityOnHandEmptyException : BaseException
{
    public QuantityOnHandEmptyException()
        : base("Quantity cannot be empty.", StatusCodes.Status400BadRequest)
    {
    }
}


#endregion