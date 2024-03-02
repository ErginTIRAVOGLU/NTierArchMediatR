using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.Products;
public sealed record CreateProductDto(
    Guid CreatedById,

    string Name,
    decimal Price,
    int Quantity,
    Guid CategoryId
) : IRequest<ErrorOr<Unit>>;
