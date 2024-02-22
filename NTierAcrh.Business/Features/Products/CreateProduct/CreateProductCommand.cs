using MediatR;

namespace NTierAcrh.Business.Features.Products.CreateProduct;
public sealed record CreateProductCommand(
    Guid CategoryId,
    string Name,
    decimal Price,
    int Quantity) : IRequest;
