using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Categories.DeleteCategory;
internal sealed class CategoryDeleteAndCategoryProductsUpdateCommandHandler : IRequestHandler<CategoryDeleteAndCategoryProductsUpdateCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public CategoryDeleteAndCategoryProductsUpdateCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(CategoryDeleteAndCategoryProductsUpdateCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(c => c.Id == request.Id, cancellationToken);
        if (category is null)
        {
            throw new ArgumentException("Kategori bulunamadı!");
        }

        if (request.newCategoryId != Guid.Empty)
        {
            var newCategory = await _categoryRepository.GetByIdAsync(c => c.Id == request.newCategoryId, cancellationToken);
            if (newCategory is null)
            {
                throw new ArgumentException("Ürünlerin aktarılacagı kategori bulunamadı!");
            }

            if (category.Products != null)
            {
                foreach (var product in category.Products)
                {
                    product.CategoryId = request.newCategoryId;
                    _productRepository.Update(product);
                }
            }
        }

        else
        {
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
                    _productRepository.Update(product);
                }
            }
        }

        _categoryRepository.Remove(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
