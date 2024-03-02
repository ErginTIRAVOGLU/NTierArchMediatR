using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.UserRoles;
public sealed record SetUserRoleDto(Guid UserId, Guid RoleId) : IRequest<ErrorOr<Unit>>;