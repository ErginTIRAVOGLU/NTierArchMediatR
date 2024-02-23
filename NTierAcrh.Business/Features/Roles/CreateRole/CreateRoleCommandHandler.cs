using AutoMapper;
using MediatR;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Roles.CreateRole;
internal sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var roleIsExists = await _roleRepository.AnyAsync(r => r.Name == request.Name, cancellationToken);
        if (roleIsExists)
        {
            throw new ArgumentException("Rol daha önce eklenmiş!");
        }

        AppRole role = _mapper.Map<AppRole>(request);

        await _roleRepository.AddAsync(role);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
