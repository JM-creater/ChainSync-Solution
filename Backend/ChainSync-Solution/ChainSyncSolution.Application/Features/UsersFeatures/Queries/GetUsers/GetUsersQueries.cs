using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Queries.GetUsers;

public class GetUsersQueries : IRequest<List<User>>
{

}