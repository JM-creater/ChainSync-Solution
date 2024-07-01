using FluentValidation;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.ForgotPassword;

public class ForgotPasswordCommandValidator : AbstractValidator<ForgotPasswordCommand>
{
    public ForgotPasswordCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithErrorCode("400");
    }
}
