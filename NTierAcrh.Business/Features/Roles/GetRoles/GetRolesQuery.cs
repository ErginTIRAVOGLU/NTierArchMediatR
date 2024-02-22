using MediatR;
using NTierAcrh.Entities.Models;

namespace NTierAcrh.Business.Features.Roles.GetRoles;
public sealed record GetRolesQuery() : IRequest<List<AppRole>>;
