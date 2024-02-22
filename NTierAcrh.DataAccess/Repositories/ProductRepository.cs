using NTierAcrh.DataAccess.Context;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.DataAccess.Repositories;

internal sealed class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}