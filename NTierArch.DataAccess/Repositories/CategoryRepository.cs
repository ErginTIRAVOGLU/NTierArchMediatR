using NTierArch.DataAccess.Context;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.DataAccess.Repositories;

internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
