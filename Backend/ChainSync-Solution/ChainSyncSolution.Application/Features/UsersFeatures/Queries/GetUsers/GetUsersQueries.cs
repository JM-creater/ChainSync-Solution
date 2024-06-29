using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Queries.GetUsers;

public sealed record GetUsersQueries : IRequest<List<User>>;