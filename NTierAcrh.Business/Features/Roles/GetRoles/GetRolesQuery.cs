﻿using MediatR;

namespace NTierAcrh.Business.Features.Roles.GetRoles;
public sealed record GetRolesQuery : IRequest<List<GetRolesQueryResponse>>;
