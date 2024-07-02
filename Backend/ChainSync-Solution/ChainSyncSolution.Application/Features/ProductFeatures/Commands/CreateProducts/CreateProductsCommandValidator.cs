using FluentValidation;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Commands.CreateProducts;

public class CreateProductsCommandValidator : AbstractValidator<CreateProductsCommand>
{
    public CreateProductsCommandValidator()
    {
        RuleFor(x => x.ProductName).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Description).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.SupplierId).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.PhoneNumber).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Price).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.ProductImage).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.QuantityOnHand).NotEmpty().WithErrorCode("400");
    }
}
