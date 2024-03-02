using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.Roles;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.Roles.DeleteRole;

internal sealed class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleDto, ErrorOr<Unit>>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteRoleDto request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(r => r.Id == request.Id, cancellationToken);
        if (role is null)
        {
            return Error.Conflict("RoleNotFound", "Rol Bulunamadı");
        }

        _roleRepository.Remove(role);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}