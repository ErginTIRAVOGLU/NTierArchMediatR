using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.Categories;
public sealed record DeleteCategoryDto(
    Guid Id,
    Guid DeletedById
) : IRequest<ErrorOr<Unit>>;