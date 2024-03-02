using MediatR;

namespace NTierArch.Entities.Events.Products.Create;
public sealed class ProductCreateEmail : INotificationHandler<ProductsDomainEvent>
{
    public Task Handle(ProductsDomainEvent notification, CancellationToken cancellationToken)
    {
        //return notification.Product.Id;
        //Mail gönderme işlemi

        return Task.CompletedTask;
    }
}
