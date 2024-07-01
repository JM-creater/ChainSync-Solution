using AutoMapper;
using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Common.Security;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Users;
using MediatR;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.ResetPassword;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ResetPasswordCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ResetPasswordRequest> Handle(ResetPasswordCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetPasswordToken(command.Token);

        if (user == null)
        {
            throw new CheckTokenExistsException(command.Token);
        }

        user.SetPassword(PasswordEncryption.HashPassword(command.NewPassword));
        user.SetPasswordResetToken(null);
        user.SetResetTokenExpires(null); 

        await _userRepository.UpdatePasswordAsync(user);
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<ResetPasswordRequest>(user);
    }
}
