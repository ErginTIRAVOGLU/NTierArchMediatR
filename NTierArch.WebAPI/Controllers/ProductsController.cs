using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArch.DataAccess.Authorization;
using NTierArch.Entities.DTOs.Products;
using NTierArch.WebAPI.Abstractions;

namespace NTierArch.WebAPI.Controllers;

public sealed class ProductsController : ApiController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [RoleFilter("Product.Add")]
    public async Task<IActionResult> Add(CreateProductDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Product.Update")]
    public async Task<IActionResult> Update(UpdateProductDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Product.Remove")]
    public async Task<IActionResult> RemoveById(DeleteProductDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Product.GetAll")]
    public async Task<IActionResult> GetAll(GetProductsDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
