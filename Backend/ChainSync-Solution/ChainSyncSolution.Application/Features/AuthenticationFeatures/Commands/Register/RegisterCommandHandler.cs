using AutoMapper;
using ChainSyncSolution.Application.Interfaces.Authentication;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Domain.Dtos;
using ChainSyncSolution.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

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
        var user = _mapper.Map<User>(command);


        if (command.ProfileImage != null)
        {
            string imagePath = await SaveProfileImages(command.ProfileImage);
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

    public async Task<string?> SaveProfileImages(IFormFile? imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
            return null;

        string mainFolder = Path.Combine(Directory.GetCurrentDirectory(), "PathImages");
        string subFolder = Path.Combine(mainFolder, "ProfileImage");

        if (!Directory.Exists(mainFolder))
        {
            Directory.CreateDirectory(mainFolder);
        }
        if (!Directory.Exists(subFolder))
        {
            Directory.CreateDirectory(subFolder);
        }

        var fileName = Path.GetFileName(imageFile.FileName);
        var filePath = Path.Combine(subFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

        return Path.Combine("PathImages", "ProfileImage", fileName);
    }
}
