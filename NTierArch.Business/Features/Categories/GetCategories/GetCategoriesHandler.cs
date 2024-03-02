using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArch.Entities.DTOs.Categories;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.Categories.GetCategories;
internal sealed class GetCategoriesHandler : IRequestHandler<GetCategoriesDto, List<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> Handle(GetCategoriesDto request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAll().Where(c => c.IsHidden == false && c.IsDeleted == false).OrderBy(c => c.Name).ToListAsync();
    }
}
