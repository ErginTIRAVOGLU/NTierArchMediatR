using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArch.Entities.DTOs.Products;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.Products.GetProducts;
internal sealed class GetProductsHandler : IRequestHandler<GetProductsDto, List<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<Product>> Handle(GetProductsDto request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAll().OrderBy(p => p.Name).ToListAsync();
    }
}
