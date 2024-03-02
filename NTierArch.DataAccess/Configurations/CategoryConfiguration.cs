using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTierArch.Entities.Models;

namespace NTierArch.DataAccess.Configurations;
internal sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasColumnType("varchar(100)");
        builder.HasMany(p => p.Products);
    }
}