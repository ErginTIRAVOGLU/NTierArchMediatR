using ErrorOr;
using MediatR;

namespace NTierAcrh.Business.Features.Categories.CategoryAndCategoryProductsDelete;
public sealed record CategoryAndCategoryProductsDeleteCommand(Guid Id) : IRequest<ErrorOr<Unit>>;
