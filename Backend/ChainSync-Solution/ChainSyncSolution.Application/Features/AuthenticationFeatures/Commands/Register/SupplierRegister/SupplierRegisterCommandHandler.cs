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
using ChainSyncSolution.Application.Common.Security;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.SupplierRegister;

public class SupplierRegisterCommandHandler : IRequestHandler<SupplierRegisterCommand, SupplierRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IExceptionConfiguration _exceptionConfiguration;

    public SupplierRegisterCommandHandler(
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

    public async Task<SupplierRequest> Handle(SupplierRegisterCommand command, CancellationToken cancellationToken)
    {
        await _exceptionConfiguration.CustomSupplierRegister(command);

        var hashedPassword = PasswordEncryption.HashPassword(command.Password);
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
