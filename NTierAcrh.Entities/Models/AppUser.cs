using Microsoft.AspNetCore.Identity;

namespace NTierAcrh.Entities.Models;
public sealed class AppUser : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);// isim soyisim birleştirme işlemi
}
