using Asp.Versioning;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.CustomerRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Commands.Register.SupplierRegister;
using ChainSyncSolution.Application.Features.AuthenticationFeatures.Queries.Login;
using ChainSyncSolution.Contracts.Common.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChainSyncSolution.ServerApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/auth")]
[AllowAnonymous]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterRequest>> Register(
         [FromBody] RegisterCommand command,
         CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpPost("register-supplier")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RegisterRequest>> RegisterSupplier(
         [FromForm] SupplierRegisterCommand command,
         CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpPost("login")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<LoginRequest>> Login(
         [FromBody] LoginQueries queries,
         CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(queries, cancellationToken);

        return Ok(response);
    }
}
