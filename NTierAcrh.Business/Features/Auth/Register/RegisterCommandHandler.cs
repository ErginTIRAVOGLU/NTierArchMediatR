using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierAcrh.Entities.Models;

namespace NTierAcrh.Business.Features.Auth.Register;

internal sealed class RegisterCommandHandler : IRequestHandler<RegisterCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
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

        return Unit.Value;
    }
}