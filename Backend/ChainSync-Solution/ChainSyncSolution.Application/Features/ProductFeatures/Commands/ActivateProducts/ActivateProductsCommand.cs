using MediatR;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Commands.ActivateProducts;

public sealed record ActivateProductsCommand(Guid Id) : IRequest<bool>;
