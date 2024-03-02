using NTierArch.Entities.Models;

namespace NTierArch.Entities.Abstractions;
public interface IJwtProvider
{
    Task<string> CreateTokenAsync(AppUser user, bool rememberMe);
}
