using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierArch.DataAccess.Context;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.DataAccess.Repositories;
internal sealed class RoleRepository : Repository<AppRole>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }
}
