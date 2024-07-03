using FluentValidation;

namespace ChainSyncSolution.Application.Features.InventoryFeatures.Commands.CreateInventory;

public class CreateInventoryCommandValidator : AbstractValidator<CreateInventoryCommand>
{
    public CreateInventoryCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.Quantity).NotEmpty().WithErrorCode("400");
        RuleFor(x => x.LastRestockedDate).NotEmpty().WithErrorCode("400");
    }
}
