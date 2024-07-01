using ChainSyncSolution.Contracts.Common.Users;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.UpdateSupplierProfile;

public sealed record UpdateSupplierProfileCommand(
    string? SupplierId,
    string Email,
    string PhoneNumber,
    string Password,
    string CompanyName,
    string Address,
    IFormFile? Document,
    string? BizLicenseNumber) : IRequest<UpdateSupplierProfileRequest>;

public sealed record UpdateSupplierProfileByIdCommand(
    Guid Id,
    UpdateSupplierProfileCommand UpdateCommand) : IRequest<UpdateSupplierProfileRequest>;
