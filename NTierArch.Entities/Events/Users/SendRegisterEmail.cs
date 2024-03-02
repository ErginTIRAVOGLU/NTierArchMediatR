using MediatR;

namespace NTierArch.Entities.Events.Users;

public sealed class SendRegisterEmail : INotificationHandler<UsersDomainEvent>
{
    public Task Handle(UsersDomainEvent notification, CancellationToken cancellationToken)
    {
        //notification.User.Id;
        //Mail gönderme işlemi

        return Task.CompletedTask;
    }
}
