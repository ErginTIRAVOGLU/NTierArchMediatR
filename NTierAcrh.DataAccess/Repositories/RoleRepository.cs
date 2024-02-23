using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTierAcrh.DataAccess.Context;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.DataAccess.Repositories;
internal sealed class RoleRepository : Repository<AppRole>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }
}
