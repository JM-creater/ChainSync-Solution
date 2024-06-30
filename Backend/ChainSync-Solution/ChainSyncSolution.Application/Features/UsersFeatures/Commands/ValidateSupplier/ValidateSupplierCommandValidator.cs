using FluentValidation;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.ValidateSupplier;

public class ValidateSupplierCommandValidator : AbstractValidator<ValidateSupplierCommand>
{
    public ValidateSupplierCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithErrorCode("400");
    }
}
