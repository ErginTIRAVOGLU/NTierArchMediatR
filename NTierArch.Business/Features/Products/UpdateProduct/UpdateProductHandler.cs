using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.Products;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.Products.UpdateProduct;
internal class UpdateProductHandler : IRequestHandler<UpdateProductDto, ErrorOr<Unit>>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateProductDto request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(p => p.Id == request.Id, cancellationToken);
        if (product is null)
        {
            return Error.Conflict("ProductNotFound","Ürün bulunamadı!");
        }
        if (product.Name != request.Name)
        {
            return Error.Conflict("ProductIsExists","Bu ürün daha önce oluşturulmuş!");
        }
        product.UpdatedDate = DateTime.Now;
        _mapper.Map(request, product);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
