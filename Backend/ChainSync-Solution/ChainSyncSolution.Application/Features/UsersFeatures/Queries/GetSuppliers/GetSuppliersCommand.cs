using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Queries.GetSuppliers;

public sealed record GetSuppliersCommand() : IRequest<List<User>>;
