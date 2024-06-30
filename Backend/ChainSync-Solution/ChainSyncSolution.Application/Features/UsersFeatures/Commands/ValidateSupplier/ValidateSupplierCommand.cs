using MediatR;

namespace ChainSyncSolution.Application.Features.UsersFeatures.Commands.ValidateSupplier;

public sealed record ValidateSupplierCommand(Guid Id) : IRequest<bool>;
