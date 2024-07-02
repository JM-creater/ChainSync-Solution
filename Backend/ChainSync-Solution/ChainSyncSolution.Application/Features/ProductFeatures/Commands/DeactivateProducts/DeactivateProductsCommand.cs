using MediatR;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Commands.DeactivateProducts;

public sealed record DeactivateProductsCommand(Guid Id) : IRequest<bool>;
