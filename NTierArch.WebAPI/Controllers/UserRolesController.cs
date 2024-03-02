using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArch.Entities.DTOs.UserRoles;
using NTierArch.WebAPI.Abstractions;

namespace NTierArch.WebAPI.Controllers;

public class UserRolesController : ApiController
{
    public UserRolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> SetRole(SetUserRoleDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }
}
