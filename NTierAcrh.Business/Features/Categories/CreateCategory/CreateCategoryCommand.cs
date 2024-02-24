using MediatR;

namespace NTierAcrh.Business.Features.Categories.CreateCategory;
public sealed record CreateCategoryCommand(
    Guid CreatedById,
    string Name
) : IRequest<Unit>;
