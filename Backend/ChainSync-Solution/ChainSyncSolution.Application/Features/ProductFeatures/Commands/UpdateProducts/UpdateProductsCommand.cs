using ChainSyncSolution.Contracts.Common.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Commands.UpdateProducts;

public sealed record UpdateProductsCommand(
     string ProductName,
     string Description,
     Guid SupplierId,
     string PhoneNumber,
     float Price,
     IFormFile ProductImage,
     int QuantityOnHand) : IRequest<UpdateProductsRequest>;


public sealed record UpdateProductsByIdCommand(
    Guid Id,
    UpdateProductsCommand UpdateCommand) : IRequest<UpdateProductsRequest>;