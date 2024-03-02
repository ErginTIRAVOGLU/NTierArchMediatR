using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.Roles;

public sealed record CreateRoleDto(string Name) : IRequest<ErrorOr<Unit>>;
