using MediatR;

namespace NTierAcrh.Business.Features.Categories.UpdateCategory;
public sealed record UpdateCategoryCommand(
    Guid Id,
    Guid UpdatedById,
    string Name
) : IRequest<Unit>;