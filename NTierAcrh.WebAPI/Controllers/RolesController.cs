using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierAcrh.Business.Features.Roles.CreateRole;
using NTierAcrh.Business.Features.Roles.GetRoles;
using NTierAcrh.WebAPI.Abstractions;

namespace NTierAcrh.WebAPI.Controllers;

public sealed class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> GetAll(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
