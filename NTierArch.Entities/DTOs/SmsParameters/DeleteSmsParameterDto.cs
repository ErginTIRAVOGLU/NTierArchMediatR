using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.SmsParameters;
public sealed record DeleteSmsParameterDto(
    Guid Id
) : IRequest<ErrorOr<Unit>>;
