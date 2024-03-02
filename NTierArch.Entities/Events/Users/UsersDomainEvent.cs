using MediatR;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.Events.Users;
public sealed class UsersDomainEvent : INotification
{
    public AppUser User { get; set; }
    public UsersDomainEvent(AppUser user)
    {
        User = user;
    }
}
