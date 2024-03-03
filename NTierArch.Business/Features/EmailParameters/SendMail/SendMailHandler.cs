using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.EmailParameters;
using NTierArch.Entities.Notifications;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.EmailParameters.SendMail;
internal sealed class SendMailHandler : IRequestHandler<SendMailDto, ErrorOr<Unit>>
{
    private readonly IEmailParameterRepository _emailRepository;

    private readonly IMediator _mediator;

    public SendMailHandler(IEmailParameterRepository emailRepository, IMediator mediator)
    {
        _emailRepository = emailRepository;
        _mediator = mediator;
    }
    public async Task<ErrorOr<Unit>> Handle(SendMailDto request, CancellationToken cancellationToken)
    {
        var result = await _emailRepository.Send(request, cancellationToken);

        if (result.IsSuccessful)
        {
            await _mediator.Publish(new SendEmailNotification());
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

        return Error.Failure("Sunucu hatası");
    }
}
