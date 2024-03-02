using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.Categories;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.Categories.UpdateCategory;

internal sealed class UpdateCategoryHandler : IRequestHandler<UpdateCategoryDto, ErrorOr<Unit>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateCategoryDto request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(c => c.Id == request.Id, cancellationToken);
        if (category is null)
        {
            return Error.Conflict("CategoryNotFound","Kategori bulunamadı!");
        }

        if (category.Name != request.Name)
        {
            var isCategoryNameExists = await _categoryRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);

            if (isCategoryNameExists)
            {
                return Error.Conflict("CategoryIsExists","Bu kategori daha önce oluşturulmuş!");
            }
        }

        //Update işleminde mapper kullanımı
        category.UpdatedDate = DateTime.Now;
        _mapper.Map(request, category);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}