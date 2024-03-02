using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NTierArch.Entities.Abstractions;
using NTierArch.Entities.DTOs.Auth;
using NTierArch.Entities.Models;

namespace NTierArch.Business.Features.Auth.Login;

internal sealed class LoginHandler : IRequestHandler<LoginDto, LoginResponseDto>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public LoginHandler(UserManager<AppUser> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginResponseDto> Handle(LoginDto request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.Where(u => u.Email == request.UserNameOrEmail || u.UserName == request.UserNameOrEmail).FirstOrDefaultAsync(cancellationToken);
        if (user is null)
        {
            throw new ArgumentException("Kullanıcı bulunamadı!");
        }

        bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!checkPassword)
        {
            throw new ArgumentException("Bilgiler dogru degil tekrar deneyin!");
        }

        string token = await _jwtProvider.CreateTokenAsync(user, request.RememberMe);

        return new(AccessToken: token, UserId: user.Id);
    }
}
