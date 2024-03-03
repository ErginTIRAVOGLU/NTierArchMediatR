using MediatR;
using NTierArch.Entities.Extentions;
using NTierArch.Entities.Repositories;

namespace NTierArch.Entities.Events.Users;
public sealed class SendUserRegisterSms : INotificationHandler<UsersDomainEvent>
{
    private readonly ISmsParameterRepository _smsParameterRepository;
    public string _subject;
    public string _body;

    public SendUserRegisterSms(ISmsParameterRepository smsParameterRepository, string subject, string body)
    {
        _smsParameterRepository = smsParameterRepository;
        _subject = subject;
        _body = body;
    }

    public Task Handle(UsersDomainEvent notification, CancellationToken cancellationToken)
    {
        var subject = _subject;
        var body = _body;
        var dto = SmsExtension.SendSmsDto(notification.User.PhoneNumber, subject, body);
        _smsParameterRepository.Send(dto, cancellationToken);

        return Task.CompletedTask;
    }
}
