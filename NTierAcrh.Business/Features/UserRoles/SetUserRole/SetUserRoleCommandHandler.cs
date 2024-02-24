using ErrorOr;
using MediatR;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.UserRoles.SetUserRole;

internal sealed class SetUserRoleCommandHandler : IRequestHandler<SetUserRoleCommand, ErrorOr<Unit>>
{
    private readonly IUserRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SetUserRoleCommandHandler(IUserRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(SetUserRoleCommand request, CancellationToken cancellationToken)
    {
        var checkIsRoleSetExists = await _roleRepository.AnyAsync(ur => ur.AppUserId == request.UserId && ur.AppRoleId == request.RoleId, cancellationToken);
        if (checkIsRoleSetExists)
        {
            return Error.Conflict("TheUserAlreadyHasThisRole", "Kullanıcı bu role zaten sahip!");
        }

        UserRole userRole = new()
        {
            AppRoleId = request.RoleId,
            AppUserId = request.UserId,
        };

        await _roleRepository.AddAsync(userRole);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
