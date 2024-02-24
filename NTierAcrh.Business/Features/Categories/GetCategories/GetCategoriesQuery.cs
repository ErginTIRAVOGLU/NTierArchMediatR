using MediatR;
using NTierAcrh.Entities.Models;

namespace NTierAcrh.Business.Features.Categories.GetCategories;
public sealed record GetCategoriesQuery : IRequest<List<Category>>;