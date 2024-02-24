using ErrorOr;
using MediatR;

namespace NTierAcrh.Business.Features.Categories.CreateCategory;
public sealed record CreateCategoryCommand(
    Guid CreatedById,
    string Name
) : IRequest<ErrorOr<Unit>>;
