using MediatR;
using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.Extentions;
public static class SmsExtension
{
    public static SendSmsDto SmsDto(AppUser user, string subject, string body)
    {
        SendSmsDto dto = new(
            body: body,
            subject: subject,
            toNumbers: user.PhoneNumber
        );
        return dto;
    }


    public static SendSmsDto SendSmsDto(string phoneNumber, string subject, string body)
    {
        SendSmsDto dto = new(
            body: body,
            subject: subject,
            toNumbers: phoneNumber
        );
        return dto;
    }
}
