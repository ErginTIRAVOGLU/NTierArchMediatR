using MediatR;

namespace NTierAcrh.Business.Features.Categories.UpdateCategory;
public sealed record UpdateCategoryCommand(
    Guid userId,
    Guid Id,
    string Name) : IRequest;
