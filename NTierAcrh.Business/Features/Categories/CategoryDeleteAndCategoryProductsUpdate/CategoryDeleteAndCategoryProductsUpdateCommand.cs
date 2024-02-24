using ErrorOr;
using MediatR;

namespace NTierAcrh.Business.Features.Categories.DeleteCategory;
public sealed record CategoryDeleteAndCategoryProductsUpdateCommand(Guid Id, Guid? newCategoryId) : IRequest<ErrorOr<Unit>>;
