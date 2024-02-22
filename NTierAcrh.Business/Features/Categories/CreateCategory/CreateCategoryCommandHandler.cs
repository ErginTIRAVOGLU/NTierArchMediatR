using MediatR;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Categories.CreateCategory;
internal sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var isCategoryNameExists = await _categoryRepository.AnyAsync(c => c.Name == request.Name, cancellationToken);
        if (isCategoryNameExists)
        {
            throw new ArgumentException("Bu kategori daha önce oluşturulmuş!");
        }

        Category category = new()
        {
            CreatedById = request.userId,
            Name = request.Name,
        };
        await _categoryRepository.AddAsync(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
