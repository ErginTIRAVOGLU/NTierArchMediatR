using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.Categories;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.Categories.DeleteCategory;
internal sealed class DeleteCategoryHandler : IRequestHandler<DeleteCategoryDto, ErrorOr<Unit>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteCategoryDto request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(c => c.Id == request.Id, cancellationToken);
        if (category is null)
        {
            return Error.Conflict("CategoryNotFound", "Kategori Bulunamadı");
        }

        category.DeletedDate = DateTime.Now;
        category.IsHidden = true;
        _mapper.Map(request, category);

        _categoryRepository.Update(category);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
