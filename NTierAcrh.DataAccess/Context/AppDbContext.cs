using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.DataAccess.Context;
public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>, IUnitOfWork
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Ignore ile İlgili Tabloların Oluşmasını Engellemekteyiz.
        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityUserRole<Guid>>();
        builder.Ignore<IdentityUserClaim<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();
        builder.Ignore<IdentityRoleClaim<Guid>>();

        //Reflection sayesinde IEntiyTypeConfiguration implemente edilen tüm dosyaları bulur tanır
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
