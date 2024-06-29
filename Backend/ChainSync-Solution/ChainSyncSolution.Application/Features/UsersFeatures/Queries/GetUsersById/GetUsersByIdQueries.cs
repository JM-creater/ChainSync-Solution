using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Queries.GetUsersById;

public sealed record GetUsersByIdQueries(Guid Id) : IRequest<User?>;
