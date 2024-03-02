using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.Categories; 
public sealed record CreateCategoryDto(
    Guid CreatedById,
    string Name
) : IRequest<ErrorOr<Unit>>;
