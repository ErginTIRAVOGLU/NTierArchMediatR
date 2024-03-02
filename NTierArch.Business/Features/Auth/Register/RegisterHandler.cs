using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierArch.Entities.DTOs.Auth;
using NTierArch.Entities.Events.Users;
using NTierArch.Entities.Models;

namespace NTierArch.Business.Features.Auth.Register;

internal sealed class RegisterHandler : IRequestHandler<RegisterDto, Unit>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMediator _mediator;

    public RegisterHandler(UserManager<AppUser> userManager, IMediator mediator)
    {
        _userManager = userManager;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(RegisterDto request, CancellationToken cancellationToken)
    {
        var checkUserNameExists = await _userManager.FindByNameAsync(request.UserName);
        if (checkUserNameExists is not null)
        {
            throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmış!");
        }

        var checkEmailExists = await _userManager.FindByEmailAsync(request.Email);
        if (checkEmailExists is not null)
        {
            throw new ArgumentException("Bu mail adresi daha önce kullanılmış!");
        }

        if (request.Password != request.RePassword)
        {
            throw new ArgumentException("Parola ve Parola tekrarı eşleşmiyor lütfen kontrol edip tekrar deneyin!");
        }

        AppUser user = new()
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.UserName
        };

        await _userManager.CreateAsync(user, request.Password);

        await _mediator.Publish(new UsersDomainEvent(user));

        return Unit.Value;
    }
}