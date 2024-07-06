using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Queries.GetProductsBySupplierId;

public sealed record GetProductsBySupplierIdQueries(string SupplierId) : IRequest<List<Product>>;
