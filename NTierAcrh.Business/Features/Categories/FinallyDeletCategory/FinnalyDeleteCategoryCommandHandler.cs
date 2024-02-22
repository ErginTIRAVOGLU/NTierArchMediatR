using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Categories.DeleteCategory;
internal sealed class FinnalyDeleteCategoryCommandHandler : IRequestHandler<FinnalyDeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FinnalyDeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(FinnalyDeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(c => c.Id == request.Id, cancellationToken);
        if (category is null)
        {
            throw new ArgumentException("Kategori bulunamadı!");
        }

        // IsMainCategory true olan başka bir kategoriyi bul
        // Find another category with IsMainCategory true
        var newMainCategory = await _categoryRepository.GetWhere(c => c.IsMainCategory == true && c.Id != request.Id)
                                                        .FirstOrDefaultAsync(cancellationToken);

        // Kategoriye bağlı ürünleri güncelle
        // Update products linked to the category
        if (category.Products != null)
        {
            foreach (var product in category.Products)
            {
                product.CategoryId = newMainCategory?.Id;
            }
        }

        _categoryRepository.Remove(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
