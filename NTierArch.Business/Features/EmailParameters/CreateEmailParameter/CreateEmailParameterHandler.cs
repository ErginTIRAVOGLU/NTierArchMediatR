using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.EmailParameters;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.EmailParameters.CreateEmailParameter;

internal sealed class UpdateEmailParameterCommandHandler : IRequestHandler<CreateEmailParameterDto, ErrorOr<Unit>>
{
    private readonly IEmailParameterRepository _emailParameterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UpdateEmailParameterCommandHandler(IEmailParameterRepository emailParameterRepository, IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    {
        _emailParameterRepository = emailParameterRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ErrorOr<Unit>> Handle(CreateEmailParameterDto request, CancellationToken cancellationToken)
    {
        var isEmailExists = await _emailParameterRepository.AnyAsync(e => e.Email == request.Email, cancellationToken);
        if (isEmailExists)
        {
            return Error.Conflict("EmailIsExists", "Bu email parametresi daha önce oluşturulmuş!");
        }
        //Create işleminde mapper kullanımı
        var emailParameter = _mapper.Map<EmailParameter>(request);

        await _emailParameterRepository.AddAsync(emailParameter);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}