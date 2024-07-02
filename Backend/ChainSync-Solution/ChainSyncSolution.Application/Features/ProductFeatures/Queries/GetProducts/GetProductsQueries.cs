using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Queries.GetProducts;

public sealed record GetProductsQueries() : IRequest<List<Product>>;
