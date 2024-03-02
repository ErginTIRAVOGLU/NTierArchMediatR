using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.SmsParameters;
public sealed record UpdateSmsParameterDto(
    Guid Id,
    string ApiUrl,
    string SenderNumber
) : IRequest<ErrorOr<Unit>>;
