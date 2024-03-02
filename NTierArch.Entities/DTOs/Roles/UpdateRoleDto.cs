using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.Roles;
public sealed record UpdateRoleDto(Guid Id, string Name) : IRequest<ErrorOr<Unit>>;