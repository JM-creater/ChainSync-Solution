using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.ValidateCustomer;

public class ValidateCustomerCommandHandler : IRequestHandler<ValidateCustomerCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ValidateCustomerCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(ValidateCustomerCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUsersByIdAsync(command.Id);

        if (user is null)
        {
            throw new CheckIdExistException(command.Id);
        }

        user.SetIsValidated(true);

        await _userRepository.UpdateCustomerValidationAsync(command.Id);
        await _unitOfWork.Save(cancellationToken);

        return true;
    }
}
