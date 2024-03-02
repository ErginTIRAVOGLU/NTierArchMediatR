using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.SmsParameters.DeleteSmsParameter;
internal sealed class DeleteSmsParameterHandler : IRequestHandler<DeleteSmsParameterDto, ErrorOr<Unit>>
{
    private readonly IEmailParameterRepository _emailParameterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteSmsParameterHandler(IEmailParameterRepository emailParameterRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _emailParameterRepository = emailParameterRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteSmsParameterDto request, CancellationToken cancellationToken)
    {
        var emailParameter = await _emailParameterRepository.GetByIdAsync(c => c.Id == request.Id, cancellationToken);
        if (emailParameter is null)
        {
            return Error.Conflict("SenderNumberNotFound", "Bu sms parametresi kaydı bulunamadı!");
        }

        _emailParameterRepository.Remove(emailParameter);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
