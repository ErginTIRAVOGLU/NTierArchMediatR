using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.Categories;
public sealed record CategoryDeleteAndCategoryProductsUpdateDto(Guid Id, Guid? newCategoryId) : IRequest<ErrorOr<Unit>>;
