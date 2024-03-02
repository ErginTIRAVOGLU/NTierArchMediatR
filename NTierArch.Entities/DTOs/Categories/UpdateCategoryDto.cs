using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.Categories;
public sealed record UpdateCategoryDto(
    Guid Id,
    Guid UpdatedById,
    string Name
) : IRequest<ErrorOr<Unit>>;
