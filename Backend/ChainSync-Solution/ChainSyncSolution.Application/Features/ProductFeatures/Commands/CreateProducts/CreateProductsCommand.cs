using ChainSyncSolution.Contracts.Common.Products;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChainSyncSolution.Application.Features.ProductFeatures.Commands.CreateProducts;

public sealed record CreateProductsCommand(
     string ProductName,
     string Description,
     Guid SupplierId,
     string PhoneNumber,
     float Price,
     IFormFile ProductImage,
     int QuantityOnHand) : IRequest<CreateProductsRequest>;
