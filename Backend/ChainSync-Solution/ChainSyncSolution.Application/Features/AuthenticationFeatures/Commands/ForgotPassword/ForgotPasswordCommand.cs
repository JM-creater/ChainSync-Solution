using ChainSyncSolution.Contracts.Common.Users;
using MediatR;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.ForgotPassword;

public sealed record ForgotPasswordCommand(
    string Email) : IRequest<ForgotPasswordRequest>;