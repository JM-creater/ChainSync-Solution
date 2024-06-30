using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.ValidateCustomer;

public sealed record ValidateCustomerCommand(Guid Id) : IRequest<bool>;
