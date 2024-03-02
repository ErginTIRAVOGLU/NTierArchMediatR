using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.SmsParameters.UpdateSmsParameter;

internal sealed class CreateSmsParameterHandler : IRequestHandler<CreateSmsParameterDto, ErrorOr<Unit>>
{
    private readonly ISmsParameterRepository _smsParameterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public CreateSmsParameterHandler(ISmsParameterRepository smsParameterRepository, IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    {
        _smsParameterRepository = smsParameterRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateSmsParameterDto request, CancellationToken cancellationToken)
    {
        var isEmailExists = await _smsParameterRepository.AnyAsync(e => e.SenderNumber == request.SenderNumber, cancellationToken);
        if (isEmailExists)
        {
            return Error.Conflict("SenderNumberExists", "Bu sms numarası daha önce oluşturulmuş!");
        }

        var smsParameter = _mapper.Map<SmsParameter>(request);

        await _smsParameterRepository.AddAsync(smsParameter);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}