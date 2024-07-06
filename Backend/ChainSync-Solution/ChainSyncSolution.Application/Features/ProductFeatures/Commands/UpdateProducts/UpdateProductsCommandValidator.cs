using FluentValidation;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Commands.UpdateProducts;

public class UpdateProductsCommandValidator : AbstractValidator<UpdateProductsCommand>
{
    public UpdateProductsCommandValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Description).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Price).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.ProductImage).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.QuantityOnHand).NotEmpty().WithErrorCode("400");
    }
}
