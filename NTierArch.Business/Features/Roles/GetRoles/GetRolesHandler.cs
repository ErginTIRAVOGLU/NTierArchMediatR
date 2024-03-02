using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArch.Entities.DTOs.Roles;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.Roles.GetRoles;

internal sealed class GetRolesHandler : IRequestHandler<GetRolesDto, List<GetRolesResponseDto>>
{
    private readonly IRoleRepository _roleRepository;

    public GetRolesHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<List<GetRolesResponseDto>> Handle(GetRolesDto request, CancellationToken cancellationToken)
    {
        var response =
            await _roleRepository.GetAll()
            .Select(r => new GetRolesResponseDto(r.Id, r.Name!))
            .ToListAsync(cancellationToken);

        return response;
    }
}
