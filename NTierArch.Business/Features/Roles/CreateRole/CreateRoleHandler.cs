using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.Roles;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.Roles.CreateRole;
internal sealed class CreateRoleHandler : IRequestHandler<CreateRoleDto, ErrorOr<Unit>>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRoleHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateRoleDto request, CancellationToken cancellationToken)
    {
        var checkRoleIsExists = await _roleRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (checkRoleIsExists)
        {
            return Error.Conflict("RoleIsExists", "Bu rol daha önce oluşturulmuş");
        }

        var role = _mapper.Map<AppRole>(request);

        await _roleRepository.AddAsync(role, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
