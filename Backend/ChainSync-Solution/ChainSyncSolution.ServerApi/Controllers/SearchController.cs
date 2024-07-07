using Asp.Versioning;
using ChainSyncSolution.Application.Features.Search.SearchProducts;
using ChainSyncSolution.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChainSyncSolution.ServerApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class SearchController : ControllerBase
{
    private readonly IMediator _mediator;

    public SearchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("search-products")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> SearchProducts([FromQuery] string productName)
    {
        var response = await _mediator.Send(new SearchProductsCommand(productName));

        return Ok(response);
    }
}
