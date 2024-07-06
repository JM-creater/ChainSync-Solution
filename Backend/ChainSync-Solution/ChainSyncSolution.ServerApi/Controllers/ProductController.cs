using Asp.Versioning;
using ChainSyncSolution.Application.Features.ProductFeatures.Commands.ActivateProducts;
using ChainSyncSolution.Application.Features.ProductFeatures.Commands.CreateProducts;
using ChainSyncSolution.Application.Features.ProductFeatures.Commands.DeactivateProducts;
using ChainSyncSolution.Application.Features.ProductFeatures.Commands.DeleteProducts;
using ChainSyncSolution.Application.Features.ProductFeatures.Commands.UpdateProducts;
using ChainSyncSolution.Application.Features.ProductFeatures.Queries.GetProducts;
using ChainSyncSolution.Application.Features.ProductFeatures.Queries.GetProductsBySupplierId;
using ChainSyncSolution.Contracts.Common.Products;
using ChainSyncSolution.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChainSyncSolution.ServerApi.Controllers;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create-product")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateProductsRequest>> CreateProducts(
        [FromForm] CreateProductsCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(response);
    }

    [HttpGet("get-products")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> GetProducts()
    {
        var response = await _mediator.Send(new GetProductsQueries());

        return Ok(response);
    }

    [HttpGet("get-products-supplierId/{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> GetProducts(string id)
    {
        var response = await _mediator.Send(new GetProductsBySupplierIdQueries(id));

        return Ok(response);
    }

    [HttpPut("activate-products/{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> ActivateProducts(Guid id)
    {
        var response = await _mediator.Send(new ActivateProductsCommand(id));

        return Ok(response);
    }

    [HttpPut("deactivate-products/{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> DeactivateProducts(Guid id)
    {
        var response = await _mediator.Send(new DeactivateProductsCommand(id));

        return Ok(response);
    }

    [HttpPut("update-products/{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> UpdateProducts(
        [FromRoute] string id,
        [FromForm] UpdateProductsCommand command,
        CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new UpdateProductsByIdCommand(id, command), cancellationToken);

        return Ok(response);
    }

    [HttpDelete("delete-products/{id}")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> DeleteProducts(Guid id)
    {
        var response = await _mediator.Send(new DeleteProductsCommand(id));

        return Ok(response);
    }
}
