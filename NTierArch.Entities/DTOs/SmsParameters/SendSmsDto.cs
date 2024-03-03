using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.SmsParameters;
public sealed record SendSmsDto(
    string subject,
    string body,
    string toNumbers
) : IRequest<ErrorOr<Unit>>;