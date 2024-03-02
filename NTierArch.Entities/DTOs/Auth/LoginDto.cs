using MediatR;

namespace NTierArch.Entities.DTOs.Auth;
public sealed record LoginDto(
    string UserNameOrEmail,
    string Password,
    bool RememberMe
) : IRequest<LoginResponseDto>;