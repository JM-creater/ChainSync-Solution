using ChainSyncSolution.Contracts.Common.Users;
using MediatR;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.ResetPassword;

public sealed record ResetPasswordCommand(
    string Token,
    string NewPassword) : IRequest<ResetPasswordRequest>;