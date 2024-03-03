using MediatR;
using NTierArch.Entities.Extentions;
using NTierArch.Entities.Repositories;

namespace NTierArch.Entities.Events.Users;

public sealed class SendUserRegisterEmail : INotificationHandler<UsersDomainEvent>
{
    private readonly IEmailParameterRepository _parameterRepository;
    public string _subject;
    public string _body;

    public SendUserRegisterEmail(IEmailParameterRepository parameterRepository, string subject, string body)
    {
        _parameterRepository = parameterRepository;
        _subject = subject;
        _body = body;
    }

    public Task Handle(UsersDomainEvent notification, CancellationToken cancellationToken)
    {
        var subject = _subject;
        var body = _body;
        var dto = EmailExtension.SendEmailDto(notification.User.Email, subject, body);
        _parameterRepository.Send(dto, cancellationToken);

        return Task.CompletedTask;
    }
}
