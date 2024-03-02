using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.Roles;
public sealed record DeleteRoleDto(Guid Id) : IRequest<ErrorOr<Unit>>;