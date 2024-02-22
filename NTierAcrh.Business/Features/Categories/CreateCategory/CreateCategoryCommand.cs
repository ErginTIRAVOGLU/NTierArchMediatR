using MediatR;

namespace NTierAcrh.Business.Features.Categories.CreateCategory;
public sealed record CreateCategoryCommand(
    Guid userId,
    string Name,
    bool IsMainCategory,
    Guid? MainCategoryId) : IRequest;
