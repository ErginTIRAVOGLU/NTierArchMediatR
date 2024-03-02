using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.Products;
using NTierArch.Entities.Events.Products;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.Products.CreateProduct;
internal sealed class CreateProductHandler : IRequestHandler<CreateProductDto, ErrorOr<Unit>>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CreateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateProductDto request, CancellationToken cancellationToken)
    {
        var isProductExists = await _productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (isProductExists)
        {
            return Error.Conflict("ProductIsExists", "Bu ürün daha önce kaydedilmiş!");
        }

        var product = _mapper.Map<Product>(request);

        await _productRepository.AddAsync(product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new ProductsDomainEvent(product));

        return Unit.Value;
    }
}
