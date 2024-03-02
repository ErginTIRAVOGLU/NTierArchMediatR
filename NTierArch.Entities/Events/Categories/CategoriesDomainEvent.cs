using MediatR;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.Events.Categories;
public sealed class CategoriesDomainEvent : INotification
{
    public Category Category { get; set; }
    public CategoriesDomainEvent(Category category)
    {
        Category = category;
    }
}
