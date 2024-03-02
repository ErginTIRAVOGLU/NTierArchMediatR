using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierArch.Entities.DTOs.Auth;
using NTierArch.WebAPI.Abstractions;

namespace NTierArch.WebAPI.Controllers;

[AllowAnonymous]
public sealed class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);
        return NoContent();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
