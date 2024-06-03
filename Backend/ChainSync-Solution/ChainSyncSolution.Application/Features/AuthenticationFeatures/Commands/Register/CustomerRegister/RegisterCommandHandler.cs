using AutoMapper;
using ChainSyncSolution.Application.Interfaces.Authentication;
using ChainSyncSolution.Application.Interfaces.ErrorControl;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Authentication;
using ChainSyncSolution.Domain.Entities;
using ChainSyncSolution.Domain.Common.Enum;
using MediatR;
using ChainSyncSolution.Application.Common.Security;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.CustomerRegister;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IExceptionConfiguration _exceptionConfiguration;

    public RegisterCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IMapper mapper,
        IJwtTokenGenerator jwtTokenGenerator,
        IExceptionConfiguration exceptionConfiguration)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
        _exceptionConfiguration = exceptionConfiguration;
    }

    public async Task<RegisterRequest> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await _exceptionConfiguration.CustomerRegisterValidator(command);

        var hashedPassword = PasswordEncryption.HashPassword(command.Password);
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
