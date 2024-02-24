using Microsoft.AspNetCore.Mvc;

namespace NTierAcrh.DataAccess.Authorization;
public sealed class RoleFilterAttribute : TypeFilterAttribute
{
    public RoleFilterAttribute(string role) : base(typeof(RoleAttribute))
    {
        Arguments = new object[] { role };
    }
}
