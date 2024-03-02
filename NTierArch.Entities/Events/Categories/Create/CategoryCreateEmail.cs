using MediatR;

namespace NTierArch.Entities.Events.Categories.Create;
public sealed class CategoryCreateEmail : INotificationHandler<CategoriesDomainEvent>
{
    public Task Handle(CategoriesDomainEvent notification, CancellationToken cancellationToken)
    {
        //return notification.Category.Id;
        //Mail gönderme işlemi
        return Task.CompletedTask;
    }
}
