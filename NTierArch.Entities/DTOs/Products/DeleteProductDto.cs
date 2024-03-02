using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.Products;
public sealed record DeleteProductDto(
    Guid Id,
    Guid DeletedById
) : IRequest<ErrorOr<Unit>>;