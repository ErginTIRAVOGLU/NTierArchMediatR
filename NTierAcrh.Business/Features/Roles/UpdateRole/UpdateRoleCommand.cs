using MediatR;

namespace NTierAcrh.Business.Features.Roles.UpdateRole;
public sealed record UpdateRoleCommand(Guid Id, string Name) : IRequest;