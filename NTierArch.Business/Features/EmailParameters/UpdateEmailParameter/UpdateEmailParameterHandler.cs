using AutoMapper;
using ErrorOr;
using MediatR;
using NTierArch.Entities.DTOs.EmailParameters;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.EmailParameters.UpdateEmailParameter;

internal sealed class UpdateEmailParameterHandler : IRequestHandler<UpdateEmailParameterDto, ErrorOr<Unit>>
{
    private readonly IEmailParameterRepository _emailParameterRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public UpdateEmailParameterHandler(IEmailParameterRepository emailParameterRepository, IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    {
        _emailParameterRepository = emailParameterRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<ErrorOr<Unit>> Handle(UpdateEmailParameterDto request, CancellationToken cancellationToken)
    {
        var emailParameter = await _emailParameterRepository.AnyAsync(e => e.Id == request.Id, cancellationToken);
        if (!emailParameter)
        {
            return Error.Conflict("EmailParameterExists", "Böyle bir email parametresi bulunmuyor!");
        }
        var isEmailExists = await _emailParameterRepository.AnyAsync(e => e.Email == request.Email, cancellationToken);
        if (isEmailExists)
        {
            return Error.Conflict("EmailIsExists", "Bu email parametresi daha önce oluşturulmuş!");
        }

        _mapper.Map(request, emailParameter);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}