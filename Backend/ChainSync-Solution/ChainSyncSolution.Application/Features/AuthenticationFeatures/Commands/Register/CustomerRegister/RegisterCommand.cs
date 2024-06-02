using ChainSyncSolution.Contracts.Common.Authentication;
using MediatR;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.CustomerRegister;

public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    string Gender,
    string CompanyName,
    string Address) : IRequest<RegisterRequest>;
