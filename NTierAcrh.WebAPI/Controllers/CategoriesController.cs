using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierAcrh.Business.Features.Categories.CreateCategory;
using NTierAcrh.Business.Features.Categories.DeleteCategory;
using NTierAcrh.Business.Features.Categories.GetCategories;
using NTierAcrh.Business.Features.Categories.UpdateCategory;
using NTierAcrh.WebAPI.Abstractions;

namespace NTierAcrh.WebAPI.Controllers;

public sealed class CategoriesController : ApiController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> RemoveById(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
