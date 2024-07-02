using ChainSyncSolution.Application.Common.Exceptions;
using FluentValidation;
using MediatR;
using ChainSyncSolution.Application.Common.Behavior.Common;

namespace ChainSyncSolution.Application.Common.Behavior;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);

        var errors = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .Distinct()
            .ToList();

        foreach (var failure in errors)
        {
            if (failure.PropertyName == "FirstName" && failure.ErrorCode == "400")
            {
                throw new FirstNameEmptyException();
            }
            if (failure.PropertyName == "LastName" && failure.ErrorCode == "400")
            {
                throw new LastNameEmptyException();
            }
            if (failure.PropertyName == "PhoneNumber" && failure.ErrorCode == "400")
            {
                throw new PhoneNumberEmptyException();
            }
            if (failure.PropertyName == "Gender" && failure.ErrorCode == "400")
            {
                throw new GenderEmptyException();
            }
            if (failure.PropertyName == "Password" && failure.ErrorCode == "400")
            {
                throw new PasswordEmptyException();
            }
            if (failure.PropertyName == "Email" && failure.ErrorCode == "400")
            {
                throw new EmailEmptyException();
            }
            if (failure.PropertyName == "Address" && failure.ErrorCode == "400")
            {
                throw new AddressEmptyException();
            }
            if (failure.PropertyName == "CompanyName" && failure.ErrorCode == "400")
            {
                throw new CompanyNameEmptyException();
            }
            if (failure.PropertyName == "BizLicenseNumber" && failure.ErrorCode == "400")
            {
                throw new BizLicenseNumberEmptyException();
            }
            if (failure.PropertyName == "SupplierId" && failure.ErrorCode == "400")
            {
                throw new SupplierIdEmptyException();
            }
            if (failure.PropertyName == "ProductName" && failure.ErrorCode == "400")
            {
                throw new ProductNameEmptyException();
            }
            if (failure.PropertyName == "Description" && failure.ErrorCode == "400")
            {
                throw new DescriptionEmptyException();
            }
            if (failure.PropertyName == "SupplierId" && failure.ErrorCode == "400")
            {
                throw new SupplierIDProductEmptyException();
            }
            if (failure.PropertyName == "PhoneNumber" && failure.ErrorCode == "400")
            {
                throw new PhoneNumberProductEmptyException();
            }
            if (failure.PropertyName == "Price" && failure.ErrorCode == "400")
            {
                throw new PriceEmptyException();
            }
            if (failure.PropertyName == "ProductImage" && failure.ErrorCode == "400")
            {
                throw new ProductImageEmptyException();
            }
            if (failure.PropertyName == "QuantityOnHand" && failure.ErrorCode == "400")
            {
                throw new QuantityOnHandEmptyException();
            }
        }

        if (errors.Any())
        {
            var errorMessages = errors
                .Select(f => f.ErrorMessage)
                .Distinct()
                .ToArray();
            throw new BadRequestException(errorMessages); 
        }

        return await next();
    }
}
