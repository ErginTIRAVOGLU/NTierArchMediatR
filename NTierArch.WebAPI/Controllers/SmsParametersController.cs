using MediatR;
using Microsoft.AspNetCore.Mvc;
using NTierArch.DataAccess.Authorization;
using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.WebAPI.Abstractions;

namespace NTierArch.WebAPI.Controllers;

public sealed class SmsParametersController : ApiController
{
    public SmsParametersController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost]
    [RoleFilter("SmsParameter.Add")]
    public async Task<IActionResult> Add(CreateSmsParameterDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("SmsParameter.Update")]
    public async Task<IActionResult> Update(UpdateSmsParameterDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("SmsParameter.Remove")]
    public async Task<IActionResult> RemoveById(DeleteSmsParameterDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        if (response.IsError)
        {
            return BadRequest(response.FirstError);
        }
        return NoContent();
    }

    [HttpPost]
    [RoleFilter("SmsParameter.GetAll")]
    public async Task<IActionResult> GetAll(GetSmsParametersDto request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
