using MediatR;

namespace NTierArch.Entities.DTOs.Auth;
public sealed record RegisterDto(
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    string Password,
    string RePassword
) : IRequest<Unit>;
