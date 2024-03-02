using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.Categories;
public sealed record CategoryAndCategoryProductsDeleteDto(Guid Id) : IRequest<ErrorOr<Unit>>;