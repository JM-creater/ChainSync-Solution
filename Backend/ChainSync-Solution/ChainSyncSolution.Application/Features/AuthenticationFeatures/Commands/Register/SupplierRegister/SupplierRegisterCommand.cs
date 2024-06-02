using ChainSyncSolution.Contracts.Common.Authentication;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.SupplierRegister;

public sealed record SupplierRegisterCommand(
    string SupplierId,
    string Email,
    string PhoneNumber,
    string Password,
    string CompanyName,
    string Address,
    IFormFile Document,
    string BizLicenseNumber) : IRequest<SupplierRequest>;
