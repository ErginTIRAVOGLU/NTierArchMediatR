using ErrorOr;
using MediatR;

namespace NTierAcrh.Business.Features.UserRoles.SetUserRole;
public sealed record SetUserRoleCommand(Guid UserId, Guid RoleId) : IRequest<ErrorOr<Unit>>;
