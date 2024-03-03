using MediatR;
using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.Notifications;
public sealed class SmsSendNotification(SmsParameter smsParameter, SendSmsDto request) : INotification
{
}
