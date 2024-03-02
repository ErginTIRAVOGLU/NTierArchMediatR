using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArch.DataAccess.Authorization;
using NTierArch.Entities.DTOs.EmailParameters;
using NTierArch.WebAPI.Abstractions;

namespace NTierArch.WebAPI.Controllers;

public sealed class EmailParametersController : ApiController
{
    public EmailParametersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [RoleFilter("EmailParameter.Add")]
    public async Task<IActionResult> Add(CreateEmailParameterDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("EmailParameter.Update")]
    public async Task<IActionResult> Update(UpdateEmailParameterDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("EmailParameter.Remove")]
    public async Task<IActionResult> RemoveById(DeleteEmailParameterDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("EmailParameter.GetAll")]
    public async Task<IActionResult> GetAll(GetEmailParametersDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
