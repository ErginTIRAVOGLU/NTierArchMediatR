using MediatR;

namespace NTierAcrh.Business.Features.Categories.UpdateCategory;
public sealed record UpdateCategoryCommand(
    Guid UpdatedById,
    Guid Id,
    string Name) : IRequest;
