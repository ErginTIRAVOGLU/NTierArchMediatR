using MediatR;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.DTOs.Products;

public sealed record GetProductsDto() : IRequest<List<Product>>;
