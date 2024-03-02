using NTierArch.DataAccess.Context;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.DataAccess.Repositories;

internal sealed class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context) : base(context)
    {
    }
}