using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArch.Entities.DTOs.Roles;
using NTierArch.WebAPI.Abstractions;

namespace NTierArch.WebAPI.Controllers;

public sealed class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetRolesDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
