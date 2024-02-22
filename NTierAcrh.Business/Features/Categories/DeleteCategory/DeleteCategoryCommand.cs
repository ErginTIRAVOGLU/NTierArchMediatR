using MediatR;

namespace NTierAcrh.Business.Features.Categories.DeleteCategory;
public sealed record DeleteCategoryCommand(
    Guid userId,
    Guid Id) : IRequest;
