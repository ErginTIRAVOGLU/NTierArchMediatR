using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Notifications;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.SmsParameters.SendSms
{
    internal sealed class SendSmsHandler : IRequestHandler<SendSmsDto, ErrorOr<Unit>>
    {
        private readonly ISmsParameterRepository _smsParameterRepository;
        private readonly IMediator _mediator;

        public SendSmsHandler(ISmsParameterRepository smsParameterRepository, IMediator mediator)
        {
            _smsParameterRepository = smsParameterRepository;
            _mediator = mediator;
        }
        public async Task<ErrorOr<Unit>> Handle(SendSmsDto request, CancellationToken cancellationToken)
        {
            var result = await _smsParameterRepository.Send(request, cancellationToken);
            var smsParameter = await _smsParameterRepository.GetFirst();

            if (result.IsSuccessful)
            {
                await _mediator.Publish(new SmsSendNotification(smsParameter, request));
            }
            if (result.ErrorMessages != null && result.ErrorMessages.Any())
            {
                foreach (var errorMessage in result.ErrorMessages)
                {
                    return Error.Failure($"Hata: {errorMessage}");
                }
            }

            if (result.ErrorMessages != null && result.ErrorMessages.Any())
            {
                var errorList = new List<string>();
                foreach (var errorMessage in result.ErrorMessages)
                {
                    errorList.Add($"Hata: {errorMessage}");
                }
                return Error.Failure(string.Join(", ", errorList));
            }


            return Unit.Value;
        }
    }
}
