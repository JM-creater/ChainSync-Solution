using FluentValidation;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.SupplierRegister;

public class SupplierRegisterCommandValidator : AbstractValidator<SupplierRegisterCommand>
{
    public SupplierRegisterCommandValidator()
    {
        RuleFor(x => x.SupplierId).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Email).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Password).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.CompanyName).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Address).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Document).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.BizLicenseNumber).NotEmpty().WithErrorCode("400");
    }
}
