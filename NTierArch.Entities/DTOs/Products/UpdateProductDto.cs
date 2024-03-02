using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.Products;
public sealed record UpdateProductDto(
    Guid Id,
    Guid UpdatedById,
    Guid CategoryId,
    string Name,
    decimal Price,
    int Quantity
 ) : IRequest<ErrorOr<Unit>>;