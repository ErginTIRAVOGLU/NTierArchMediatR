using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NTierArch.DataAccess.Context;
using NTierArch.Entities.Abstractions;
using NTierArch.Entities.Models;
using NTierArch.Entities.Options;

namespace NTierArch.DataAccess.Services;
internal sealed class JwtProvider : IJwtProvider
{
    private readonly AppDbContext _appDbContext;
    private readonly Jwt _jwt;

    public JwtProvider(AppDbContext appDbContext, IOptions<Jwt> jwt)
    {
        _appDbContext = appDbContext;
        _jwt = jwt.Value;
    }

    public async Task<string> CreateTokenAsync(AppUser user, bool rememberMe)
    {
        IEnumerable<Claim> claims = new List<Claim>()
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim("Email", user.Email!),
            new Claim("UserName", user.UserName!),
            new Claim("FullName", user.FullName!)
        };
        var expires = rememberMe ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(1);

        JwtSecurityToken securityToken = new(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SecretKey)),
            SecurityAlgorithms.HmacSha512));

        JwtSecurityTokenHandler handler = new();
        string token = handler.WriteToken(securityToken);

        return token;
    }
}
