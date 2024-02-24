using AutoMapper;
using MediatR;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;

namespace NTierAcrh.Business.Features.Roles.CreateRole;
internal sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Unit>
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

    public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var checkRoleIsExists = await _roleRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
        if (checkRoleIsExists)
        {
            throw new ArgumentException("Bu rol daha önce oluşturulmuş");
        }

        var role = _mapper.Map<AppRole>(request);
        //AppRole? role = new()
        //{
        //    Id = Guid.NewGuid(),
        //    Name = request.Name
        //};

        await _roleRepository.AddAsync(role, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
