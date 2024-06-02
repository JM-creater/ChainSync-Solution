using AutoMapper;
using ChainSyncSolution.Application.Interfaces.Authentication;
using ChainSyncSolution.Application.Interfaces.ErrorControl;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Authentication;
using ChainSyncSolution.Domain.Entities;
using ChainSyncSolution.Domain.Common.Enum;
using MediatR;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.CustomerRegister;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IExceptionConfiguration _exceptionConfiguration;
    private readonly IPasswordEncryption _passwordEncryption;

    public RegisterCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IMapper mapper,
        IJwtTokenGenerator jwtTokenGenerator,
        IExceptionConfiguration exceptionConfiguration,
        IPasswordEncryption passwordEncryption)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
        _exceptionConfiguration = exceptionConfiguration;
        _passwordEncryption = passwordEncryption;
    }

    public async Task<RegisterRequest> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await _exceptionConfiguration.CustomerRegisterValidator(command);

        var hashedPassword = _passwordEncryption.HashPassword(command.Password);
        var user = _mapper.Map<User>(command);
        user.SetPassword(hashedPassword);

        var token = _jwtTokenGenerator.GenerateToken(user);
        var register = _mapper.Map<RegisterRequest>(user);
       

        register.Token = token;
        register.Role = UserRole.Customer;

        user.SetDateCreated(DateTimeOffset.Now);

        await _unitOfWork.Save(cancellationToken);
        await _userRepository.RegisterAsync(user, cancellationToken);

        return register;
    }
}
