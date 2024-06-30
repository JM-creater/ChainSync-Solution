using ChainSyncSolution.Contracts.Common.Users;
using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.UpdateCustomerProfile;

public sealed record UpdateCustomerProfileCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    string Password,
    string Gender,
    string CompanyName,
    string Address) : IRequest<UpdateCustomerProfileRequest>;