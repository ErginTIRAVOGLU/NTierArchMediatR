using AutoMapper;
using MediatR;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Roles.UpdateRole;

internal sealed class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Unit>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
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

        _mapper.Map(request, role);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}