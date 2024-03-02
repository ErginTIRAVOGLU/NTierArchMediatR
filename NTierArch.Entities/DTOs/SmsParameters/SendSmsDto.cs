using ErrorOr;
using MediatR;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.DTOs.SmsParameters;
public sealed record SendSmsDto(
    SmsParameter smsParameter,
    string subject,
    string body,
    string toNumbers
) : IRequest<ErrorOr<Unit>>;