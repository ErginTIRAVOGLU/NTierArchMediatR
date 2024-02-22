namespace NTierAcrh.Entities.Models;
public sealed class Product
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? CategoryId { get; set; }
    //public Category? Category { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public int Quantity { get; set; } = 0;
}
