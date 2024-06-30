using FluentValidation;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.ValidateCustomer;

public class ValidateCustomerCommandValidator : AbstractValidator<ValidateCustomerCommand>
{
    public ValidateCustomerCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithErrorCode("400");
    }
}
