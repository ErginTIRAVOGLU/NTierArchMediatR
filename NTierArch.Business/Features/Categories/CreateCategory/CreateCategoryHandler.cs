using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.Categories;
using NTierArch.Entities.Events.Categories;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.Categories.CreateCategory;
internal sealed class CreateCategoryHandler : IRequestHandler<CreateCategoryDto, ErrorOr<Unit>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CreateCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateCategoryDto request, CancellationToken cancellationToken)
    {
        var isCategoryNameExists = await _categoryRepository.AnyAsync(c => c.Name == request.Name, cancellationToken);
        if (isCategoryNameExists)
        {
            return Error.Conflict("NameIsExists","Bu kategori daha önce oluşturulmuş!");
        }
        //Create işleminde mapper kullanımı
        var category = _mapper.Map<Category>(request);

        await _categoryRepository.AddAsync(category);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new CategoriesDomainEvent(category));


        return Unit.Value;
    }
}
