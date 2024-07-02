using MediatR;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Commands.DeleteProducts;

public sealed record DeleteProductsCommand(Guid Id) : IRequest<int>;