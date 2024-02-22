namespace NTierAcrh.Entities.Models;
public sealed class Category
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public ICollection<Product>? Products { get; set; }
}
