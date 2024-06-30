using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.ValidateSupplier;

public class ValidateSupplierCommandHandler : IRequestHandler<ValidateSupplierCommand, bool>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ValidateSupplierCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(ValidateSupplierCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUsersByIdAsync(command.Id);

        if (user is null)
        {
            throw new CheckIdExistException(command.Id);
        }

        user.SetIsValidated(true);

        await _userRepository.UpdateSupplierValidationAsync(command.Id);
        await _unitOfWork.Save(cancellationToken);

        return true;
    }
}
