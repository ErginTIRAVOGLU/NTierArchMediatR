using NTierArch.Entities.Abstractions;

namespace NTierArch.Entities.Models;
public sealed class Category : Entity
{
    public string Name { get; set; } = string.Empty;
    public bool IsMainCategory { get; set; } = false;
    public Guid? MainCategoryId { get; set; }
    //public Category? MainCategory { get; set; }
    //public ICollection<Category>? SubCategories { get; set; }
    public ICollection<Product> Products { get; set; }
}


//burada cycle yiyecegiz bunu listeyi alınca yada sonucu alınca tekrar işleyerek çözebiliriz ilerleyen vakitlerde çözüm bulacagım buna şimdilik kapatıyorum ilişkileri yani 
// .Include(p => p.MainCategory) bu şekilde bulamayız şuan için .ThenInclude(c => c.SubCategories) yapamayız