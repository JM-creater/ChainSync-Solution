using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Queries.GetUsersById;

public class GetUsersByIdQueriesHandler : IRequestHandler<GetUsersByIdQueries, User?>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public GetUsersByIdQueriesHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<User?> Handle(
        GetUsersByIdQueries queries,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUsersByIdAsync(queries.Id);

        await _unitOfWork.Save(cancellationToken);

        return user;
    }
}
