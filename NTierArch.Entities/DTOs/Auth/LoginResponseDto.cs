namespace NTierArch.Entities.DTOs.Auth;
public sealed record LoginResponseDto(
    string AccessToken,
    Guid UserId
);