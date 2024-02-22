using NTierAcrh.DataAccess.Context;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.DataAccess.Repositories;

internal sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context) : base(context)
    {
    }
}