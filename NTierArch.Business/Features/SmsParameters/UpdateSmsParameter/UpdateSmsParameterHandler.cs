using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.SmsParameters.UpdateSmsParameter;

internal sealed class UpdateSmsParameterHandler : IRequestHandler<UpdateSmsParameterDto, ErrorOr<Unit>>
{
    private readonly ISmsParameterRepository _smsParameterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UpdateSmsParameterHandler(ISmsParameterRepository smsParameterRepository, IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    {
        _smsParameterRepository = smsParameterRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateSmsParameterDto request, CancellationToken cancellationToken)
    {
        var smsParamaeter = await _smsParameterRepository.AnyAsync(e => e.Id == request.Id, cancellationToken);
        if (!smsParamaeter)
        {
            return Error.Conflict("SenderNumberNotFound", "Bu sms parametresi kaydı bulunamadı!");
        }
        var isEmailExists = await _smsParameterRepository.AnyAsync(e => e.SenderNumber == request.SenderNumber, cancellationToken);
        if (isEmailExists)
        {
            return Error.Conflict("SenderNumberExists", "Bu sms numarası daha önce oluşturulmuş!");
        }

        _mapper.Map(request, smsParamaeter);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}