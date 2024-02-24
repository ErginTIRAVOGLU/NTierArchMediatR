using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierAcrh.Business.Features.Products.CreateProduct;
using NTierAcrh.Business.Features.Products.DeleteProduct;
using NTierAcrh.Business.Features.Products.GetProducts;
using NTierAcrh.Business.Features.Products.UpdateProduct;
using NTierAcrh.WebAPI.Abstractions;

namespace NTierAcrh.WebAPI.Controllers;

public sealed class ProductsController : ApiController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> RemoveById(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
