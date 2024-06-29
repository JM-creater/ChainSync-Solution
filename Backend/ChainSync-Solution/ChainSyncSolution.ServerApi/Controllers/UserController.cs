using Asp.Versioning;
using ChainSyncSolution.Application.Features.UsersFeatures.Queries.GetUsers;
using ChainSyncSolution.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChainSyncSolution.ServerApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-users")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<User>> GetUsers()
    {
        var response = await _mediator.Send(new GetUsersQueries());

        return Ok(response);
    }
}
