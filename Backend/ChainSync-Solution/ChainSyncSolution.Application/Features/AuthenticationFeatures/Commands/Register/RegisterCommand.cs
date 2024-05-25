using ChainSyncSolution.Contracts.Common.Authentication;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register;

public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    string CompanyName,
    IFormFile ProfileImage) : IRequest<RegisterRequest>;
