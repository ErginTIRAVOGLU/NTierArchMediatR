using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.EmailParameters;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.EmailParameters.DeleteEmailParameter;
internal sealed class DeleteEmailParameterHandler : IRequestHandler<DeleteEmailParameterDto, ErrorOr<Unit>>
{
    private readonly IEmailParameterRepository _emailParameterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteEmailParameterHandler(IEmailParameterRepository emailParameterRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _emailParameterRepository = emailParameterRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteEmailParameterDto request, CancellationToken cancellationToken)
    {
        var emailParameter = await _emailParameterRepository.GetByIdAsync(c => c.Id == request.Id, cancellationToken);
        if (emailParameter is null)
        {
            return Error.Conflict("EmailParameterNotFound", "e-Mail Parametresi Bulunamadı");
        }

        _emailParameterRepository.Remove(emailParameter);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
