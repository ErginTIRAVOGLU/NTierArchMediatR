using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.EmailParameters;
public sealed record CreateEmailParameterDto(
    string Smtp,
    string Email,
    string Password,
    string Port,
    string SSL
) : IRequest<ErrorOr<Unit>>;
