using MediatR;

namespace NTierAcrh.Business.Features.Categories.DeleteCategory;
public sealed record DeleteCategoryCommand(
    Guid DeletedById,
    Guid Id) : IRequest;
