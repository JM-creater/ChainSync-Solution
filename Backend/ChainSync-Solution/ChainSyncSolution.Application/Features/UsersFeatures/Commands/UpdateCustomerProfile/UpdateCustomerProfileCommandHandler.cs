using AutoMapper;
using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Common.Security;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Users;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.UpdateCustomerProfile;

public class UpdateCustomerProfileCommandHandler : IRequestHandler<UpdateCustomerProfileByIdCommand, UpdateCustomerProfileRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateCustomerProfileCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateCustomerProfileRequest> Handle(
        UpdateCustomerProfileByIdCommand command,
        CancellationToken cancellationToken)
    {
        var updateCommand = command.UpdateCommand;

        var user = await _userRepository.GetUsersByIdAsync(command.Id);

        if (user == null)
        {
            throw new CheckIdExistException(command.Id);
        }

        if (updateCommand.FirstName != null)
        {
            user.SetFirstName(updateCommand.FirstName);
        }
        if (updateCommand.LastName != null)
        {
            user.SetLastName(updateCommand.LastName);
        }
        if (updateCommand.Email != null)
        {
            user.SetEmail(updateCommand.Email);
        }
        if (updateCommand.PhoneNumber != null)
        {
            user.SetPhoneNumber(updateCommand.PhoneNumber);
        }
        if (updateCommand.Password != null)
        {
            user.SetPassword(PasswordEncryption.HashPassword(updateCommand.Password));
        }
        if (updateCommand.Gender != null)
        {
            user.SetGender(updateCommand.Gender);
        }
        if (updateCommand.CompanyName != null)
        {
            user.SetCompanyName(updateCommand.CompanyName);
        }
        if (updateCommand.Address != null)
        {
            user.SetAddress(updateCommand.Address);
        }

        user.SetDateUpdated(DateTimeOffset.Now);

        await _userRepository.UpdateProfileAsync(user, cancellationToken);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<UpdateCustomerProfileRequest>(user);
    }
}
