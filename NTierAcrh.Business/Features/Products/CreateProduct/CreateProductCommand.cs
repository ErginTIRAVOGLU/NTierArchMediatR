using ErrorOr;
using MediatR;

namespace NTierAcrh.Business.Features.Products.CreateProduct;
public sealed record CreateProductCommand(
    Guid CreatedById,

    string Name,
    decimal Price,
    int Quantity,
    Guid CategoryId
) : IRequest<ErrorOr<Unit>>;
