using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Roles.GetRoles;

internal sealed class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<AppRole>>
{
    private readonly IRoleRepository _roleRepository;

    public GetRolesQueryHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<List<AppRole>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return await _roleRepository.GetAll().OrderBy(r => r.Name).ToListAsync();
    }
}
