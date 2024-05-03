using FluentValidation;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Queries.Login;

public class LoginQueriesValidator : AbstractValidator<LoginQueries>
{
    public LoginQueriesValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
