using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArch.DataAccess.Authorization;
using NTierArch.Entities.DTOs.Categories;
using NTierArch.WebAPI.Abstractions;

namespace NTierArch.WebAPI.Controllers;

public sealed class CategoriesController : ApiController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [RoleFilter("Category.Add")]
    public async Task<IActionResult> Add(CreateCategoryDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Category.Update")]
    public async Task<IActionResult> Update(UpdateCategoryDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Category.Remove")]
    public async Task<IActionResult> RemoveById(DeleteCategoryDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("Category.GetAll")]
    public async Task<IActionResult> GetAll(GetCategoriesDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
