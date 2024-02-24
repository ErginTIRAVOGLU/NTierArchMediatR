using MediatR;

namespace NTierAcrh.Business.Features.Roles.DeleteRole;
public sealed record DeleteRoleCommand(Guid Id) : IRequest<Unit>;