using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.Search.SearchProducts;

public sealed record SearchProductsCommand(string ProductName) : IRequest<List<Product>>;
