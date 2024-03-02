using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using NTierArch.Entities.Repositories;

namespace NTierArch.DataAccess.Authorization;
public sealed class RoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _roleName;
    private readonly IUserRoleRepository _userRoleRepository;

    public RoleAttribute(IUserRoleRepository userRoleRepository, string roleName)
    {
        _userRoleRepository = userRoleRepository;
        _roleName = roleName;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var userIdClaim = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        var userHasRole = 
            _userRoleRepository.GetWhere(ur => ur.AppUserId.ToString() == userIdClaim.Value)
            .Include(ur => ur.AppRole)
            .Any(ur => ur.AppRole!.Name == _roleName);

        if (!userHasRole)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }
}
