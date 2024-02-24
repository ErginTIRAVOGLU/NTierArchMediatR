using ErrorOr;
using MediatR;

namespace NTierAcrh.Business.Features.Categories.DeleteCategory;
public sealed record DeleteCategoryCommand(
    Guid Id,
    Guid DeletedById
) : IRequest<ErrorOr<Unit>>;
