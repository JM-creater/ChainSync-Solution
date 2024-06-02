using AutoMapper;
using ChainSyncSolution.Application.Assets;
using ChainSyncSolution.Application.Interfaces.Authentication;
using ChainSyncSolution.Application.Interfaces.ErrorControl;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Authentication;
using ChainSyncSolution.Domain.Entities;
using ChainSyncSolution.Domain.Common.Enum;
using MediatR;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.SupplierRegister;

public class SupplierRegisterCommandHandler : IRequestHandler<SupplierRegisterCommand, SupplierRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IExceptionConfiguration _exceptionConfiguration;
    private readonly IPasswordEncryption _passwordEncryption;

    public SupplierRegisterCommandHandler(
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

    public async Task<SupplierRequest> Handle(SupplierRegisterCommand command, CancellationToken cancellationToken)
    {
        await _exceptionConfiguration.CustomSupplierRegister(command);

        var hashedPassword = _passwordEncryption.HashPassword(command.Password);
        var user = _mapper.Map<User>(command);
        user.SetPassword(hashedPassword);

        if (command.Document != null)
        {
            string imagePath = await new AssetConfiguration().SaveDocumentsImages(command.Document);
            user.SetDocument(imagePath);
        }

        var token = _jwtTokenGenerator.GenerateSupplierToken(user);
        var register = _mapper.Map<SupplierRequest>(user);
       
        register.Token = token;
        register.Role = UserRole.Supplier;

        await _unitOfWork.Save(cancellationToken);
        await _userRepository.RegisterAsync(user, cancellationToken);

        return register;
    }
}
