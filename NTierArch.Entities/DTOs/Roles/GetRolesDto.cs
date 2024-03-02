using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NTierArch.Entities.DTOs.Roles;
public sealed record GetRolesDto : IRequest<List<GetRolesResponseDto>>;