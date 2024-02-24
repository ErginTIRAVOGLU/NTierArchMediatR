using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Categories.CategoryAndCategoryProductsDelete;

internal sealed class CategoryAndCategoryProductsDeleteCommandHandler : IRequestHandler<CategoryAndCategoryProductsDeleteCommand, ErrorOr<Unit>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;

    public CategoryAndCategoryProductsDeleteCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IProductRepository productRepository)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(CategoryAndCategoryProductsDeleteCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(c => c.Id == request.Id, cancellationToken);
        if (category is null)
        {
            return Error.Conflict("CategoryNotFound", "Kategori bulunamadı!");
        }

        var products = await _productRepository.GetAll().Where(p => p.CategoryId == category.Id).ToListAsync();
        //if (products is null)
        //{
        //    return Error.Conflict("CategoryProductsNotFound", "Kategoriye ait ürün bulunamadı!");
        //}

        _productRepository.RemoveRange(products);
        _categoryRepository.Remove(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
