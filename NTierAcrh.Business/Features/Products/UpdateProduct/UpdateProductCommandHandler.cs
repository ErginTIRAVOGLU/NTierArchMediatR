using MediatR;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Products.UpdateProduct;
internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(p => p.Id == request.Id, cancellationToken);
        if (product is null)
        {
            throw new ArgumentException("Ürün bulunamadı!");
        }
        if (product.Name != request.Name)
        {
            throw new ArgumentException("Bu ürün daha önce oluşturulmuş!");
        }
        product.CategoryId = request.CategoryId;
        product.Name = request.Name;
        product.Price = request.Price;
        product.Quantity = request.Quantity;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
