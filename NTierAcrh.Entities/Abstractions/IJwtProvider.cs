using NTierAcrh.Entities.Models;

namespace NTierAcrh.Entities.Abstractions;
public interface IJwtProvider
{
    Task<string> CreateTokenAsync(AppUser user, bool rememberMe);
}
