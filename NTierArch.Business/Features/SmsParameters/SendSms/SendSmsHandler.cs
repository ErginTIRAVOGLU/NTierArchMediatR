using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.SmsParameters;

namespace NTierArch.Business.Features.SmsParameters.SendSms;
internal sealed class SendSmsHandler : IRequestHandler<SendSmsDto, ErrorOr<Unit>>
{
    public Task<ErrorOr<Unit>> Handle(SendSmsDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
