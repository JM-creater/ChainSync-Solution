using FluentValidation;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.CustomerRegister;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.LastName).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Email).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Password).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Gender).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.CompanyName).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Address).NotEmpty().WithErrorCode("400");
    }
}
