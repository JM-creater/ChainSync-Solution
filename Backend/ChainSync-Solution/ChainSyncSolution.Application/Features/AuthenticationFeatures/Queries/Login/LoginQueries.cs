using ChainSyncSolution.Contracts.Common.Authentication;
using MediatR;

namespace ChainSyncSolution.Application.Features.AuthenticationFeatures.Queries.Login;

public sealed record LoginQueries(
    string Email,
    string Password) : IRequest<LoginRequest>;
