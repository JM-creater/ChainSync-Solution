using AutoMapper;
using ChainSyncSolution.Application.Assets;
using ChainSyncSolution.Application.Common.Exceptions;
using ChainSyncSolution.Application.Common.Security;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Contracts.Common.Users;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.UpdateSupplierProfile;

public class UpdateSupplierProfileCommandHandler : IRequestHandler<UpdateSupplierProfileByIdCommand, UpdateSupplierProfileRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateSupplierProfileCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateSupplierProfileRequest> Handle(UpdateSupplierProfileByIdCommand command, CancellationToken cancellationToken)
    {
        var updateCommand = command.UpdateCommand;

        var user = await _userRepository.GetUsersByIdAsync(command.Id);

        if (user == null)
        {
            throw new CheckIdExistException(command.Id);
        }

        if (updateCommand.SupplierId != null)
        {
            user.SetSupplierId(updateCommand.SupplierId);
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
        if (updateCommand.Address != null)
        {
            user.SetPhoneNumber(updateCommand.Address);
        }
        if (updateCommand.Document != null)
        {
            string imagePath = await new AssetConfiguration().SaveDocumentsImages(updateCommand.Document);
            user.SetDocument(imagePath);
        }
        if (updateCommand.BizLicenseNumber != null)
        {
            user.SetBizLicenseNumber(updateCommand.BizLicenseNumber);
        }

        user.SetDateUpdated(DateTimeOffset.Now);

        await _userRepository.UpdateProfileAsync(user, cancellationToken);  
        await _unitOfWork.Save(cancellationToken);

        return _mapper.Map<UpdateSupplierProfileRequest>(user);

    }
}
