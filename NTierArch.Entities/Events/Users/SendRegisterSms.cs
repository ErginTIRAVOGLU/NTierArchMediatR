using MediatR;

namespace NTierArch.Entities.Events.Users;
public sealed class SendRegisterSms : INotificationHandler<UsersDomainEvent>
{
    public Task Handle(UsersDomainEvent notification, CancellationToken cancellationToken)
    {
        //notification.User.Id;
        //SMS gönderme işlemi

        return Task.CompletedTask;
    }
}
