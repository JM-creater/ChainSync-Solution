using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Queries.GetProductsById;

public sealed record GetProductsByIdQueries(Guid Id) : IRequest<Product?>;
