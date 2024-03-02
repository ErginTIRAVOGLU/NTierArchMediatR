using MediatR;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.Events.Products;
public sealed class ProductsDomainEvent : INotification
{
    public Product Product { get; set; }
    public ProductsDomainEvent(Product product)
    {
        Product = product;
    }
}
