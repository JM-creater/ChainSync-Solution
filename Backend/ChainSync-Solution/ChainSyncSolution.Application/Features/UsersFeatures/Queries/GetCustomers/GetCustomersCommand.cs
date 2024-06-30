using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Queries.GetCustomers;

public sealed record GetCustomersCommand() : IRequest<List<User>>;
