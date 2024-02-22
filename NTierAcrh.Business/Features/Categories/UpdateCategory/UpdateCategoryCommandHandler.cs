using MediatR;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Categories.UpdateCategory;

internal sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(c => c.Id == request.Id, cancellationToken);
        if (category is null)
        {
            throw new ArgumentException("Kategori bulunamadı!");
        }

        if (category.Name != request.Name)
        {
            throw new ArgumentException("Bu kategori daha önce oluşturulmuş!");
        }

        category.Name = request.Name;
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}