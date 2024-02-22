using MediatR;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Products.CreateProduct;
internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var isProductExists = await _productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (isProductExists)
        {
            throw new ArgumentException("Bu ürün daha önce kaydedilmiş!");
        }

        Product product = new()
        {
            CategoryId = request.CategoryId,
            Name = request.Name,
            Price = request.Price,
            Quantity = request.Quantity,
        };

        await _productRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
