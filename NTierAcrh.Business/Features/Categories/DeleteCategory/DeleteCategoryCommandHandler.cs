using MediatR;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Categories.DeleteCategory;
internal sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(c => c.Id == request.Id, cancellationToken);
        if (category is null)
        {
            throw new ArgumentException("Kategori bulunamadı!");
        }
        category.DeletedById = request.userId;
        category.DeletedDate = DateTime.Now;
        category.IsDeleted = true;
        _categoryRepository.Update(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
