using NTierAcrh.DataAccess.Context;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.DataAccess.Repositories;

internal sealed class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
