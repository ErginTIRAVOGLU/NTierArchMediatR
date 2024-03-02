using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.EmailParameters;

namespace NTierArch.Business.Features.EmailParameters.SendMail;
internal sealed class SendMailHandler : IRequestHandler<SendMailDto, ErrorOr<Unit>>
{
    public Task<ErrorOr<Unit>> Handle(SendMailDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
