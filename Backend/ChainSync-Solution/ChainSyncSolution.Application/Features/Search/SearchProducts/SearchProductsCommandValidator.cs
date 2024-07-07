using FluentValidation;

namespace ChainSyncSolution.Application.Features.Search.SearchProducts;

public class SearchProductsCommandValidator : AbstractValidator<SearchProductsCommand>
{
    public SearchProductsCommandValidator()
    {
        RuleFor(x => x.ProductName).MaximumLength(20);
    }
}
