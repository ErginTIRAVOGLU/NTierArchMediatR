using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierAcrh.Business.Features.UserRoles.SetUserRole;
using NTierAcrh.WebAPI.Abstractions;

namespace NTierAcrh.WebAPI.Controllers;

public class UserRolesController : ApiController
{
    public UserRolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> SetRole(SetUserRoleCommand request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }
}
