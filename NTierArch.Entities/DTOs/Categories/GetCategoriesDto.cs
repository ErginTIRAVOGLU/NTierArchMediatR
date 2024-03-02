using MediatR;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.DTOs.Categories;
public sealed record GetCategoriesDto : IRequest<List<Category>>;
