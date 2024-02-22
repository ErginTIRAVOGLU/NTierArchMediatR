﻿using MediatR;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Roles.UpdateRole;

internal sealed class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetByIdAsync(r => r.Id == request.Id, cancellationToken);
        if (role is null)
        {
            throw new ArgumentException("Rol bulunamadı!");
        }
        if (role.Name != request.Name)
        {
            throw new ArgumentException("Bu rol daha önce eklenmiş");
        }

        role.Name = request.Name;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}