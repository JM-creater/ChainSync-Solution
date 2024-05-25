using AutoMapper;
using ChainSyncSolution.Application.Assets;
using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Interfaces.Authentication;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Authentication;
using ChainSyncSolution.Domain.Entities;
using MediatR;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IMapper mapper,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<RegisterRequest> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            throw new EmailExistsException(command.Email);
        }

        var user = _mapper.Map<User>(command);

        if (command.ProfileImage != null)
        {
            string imagePath = await new AssetConfiguration().SaveProfileImages(command.ProfileImage);
            user.ProfileImage = imagePath;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        var register = _mapper.Map<RegisterRequest>(user);

        register.Token = token;

        _userRepository.Create(user);

        await _unitOfWork.Save(cancellationToken);

        await _userRepository.Register(user);

        return register;
    }
}
