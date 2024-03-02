using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.SmsParameters;
public sealed record CreateSmsParameterDto(
    string ApiUrl,
    string SenderNumber
) : IRequest<ErrorOr<Unit>>;