using AutoMapper;
using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Interfaces.Authentication;
using ChainSyncSolution.Application.Interfaces.IEmail;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Users;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.ForgotPassword;

public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, ForgotPasswordRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IEmailContentProvider _emailContentProvider;

    public ForgotPasswordCommandHandler(
        IUserRepository userRepository,
        IJwtTokenGenerator jwtTokenGenerator,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IConfiguration configuration,
        IEmailContentProvider emailContentProvider)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
        _emailContentProvider = emailContentProvider;
    }

    public async Task<ForgotPasswordRequest> Handle(ForgotPasswordCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmailAsync(command.Email);

        if (user == null)
        {
            throw new CheckEmailLoginException(command.Email);
        }

        var request = _mapper.Map<ForgotPasswordRequest>(command);
        var passwordToken = _jwtTokenGenerator.GeneratePasswordToken(user);

        user.SetPasswordResetToken(passwordToken);
        user.SetResetTokenExpires(DateTime.Now.AddMinutes(3));

        await _emailContentProvider.SendPasswordForgotEmail(request.Email, passwordToken);

        await _userRepository.UpdatePasswordAsync(user);
        await _unitOfWork.Save(cancellationToken);

        return request;
    }
}
