using AutoMapper;
using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Common.Security;
using ChainSyncSolution.Application.Interfaces.ErrorControl;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Users;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.UpdateCustomerProfile;

public class UpdateCustomerProfileCommandHandler : IRequestHandler<UpdateCustomerProfileCommand, UpdateCustomerProfileRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IExceptionConfiguration _exceptionConfiguration;
    public UpdateCustomerProfileCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IExceptionConfiguration exceptionConfiguration)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _exceptionConfiguration = exceptionConfiguration;
    }

    public async Task<UpdateCustomerProfileRequest> Handle(
        UpdateCustomerProfileCommand command,
        CancellationToken cancellationToken)
    {
        await _exceptionConfiguration.CustomUpdateCustomerProfile(command);

        var user = await _userRepository.GetUsersByIdAsync(command.Id);

        if (user == null)
        {
            throw new CheckIdExistException(command.Id);
        }

        var updatedUser = _mapper.Map(command, user);

        updatedUser.SetPassword(PasswordEncryption.HashPassword(command.Password));
        updatedUser.SetDateUpdated(DateTimeOffset.Now);

        await _userRepository.UpdateCustomerProfile(command.Id, updatedUser, cancellationToken);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<UpdateCustomerProfileRequest>(updatedUser);
    }
}
