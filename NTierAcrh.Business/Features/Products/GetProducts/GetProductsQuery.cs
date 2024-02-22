using MediatR;
using NTierAcrh.Entities.Models;

namespace NTierAcrh.Business.Features.Products.GetProducts;
public sealed record GetProductsQuery() : IRequest<List<Product>>;