using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Categories.GetCategories;
internal sealed class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<Category>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository.GetAll().OrderBy(c => c.Name).ToListAsync();
    }
}
