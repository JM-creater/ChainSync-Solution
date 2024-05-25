using FluentValidation;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.CompanyName).NotEmpty();
        RuleFor(x => x.ProfileImage).NotEmpty();
    }
}
