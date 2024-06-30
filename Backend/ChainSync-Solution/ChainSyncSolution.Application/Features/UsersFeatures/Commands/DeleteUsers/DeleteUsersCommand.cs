using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.DeleteUsers;

public sealed record DeleteUsersCommand(Guid Id) : IRequest<int>;