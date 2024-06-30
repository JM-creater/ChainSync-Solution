using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Interfaces.Persistence;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.DeleteUsers;

public class DeleteUsersCommandHandler : IRequestHandler<DeleteUsersCommand, int>
{
    private readonly IUserRepository _userRepository;
    public DeleteUsersCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<int> Handle(DeleteUsersCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUsersByIdAsync(command.Id);

        if (user == null)
        {
            throw new CheckIdExistException(command.Id);
        }

        return await _userRepository.DeleteUsersAsync(user.Id, cancellationToken);
    }
}
