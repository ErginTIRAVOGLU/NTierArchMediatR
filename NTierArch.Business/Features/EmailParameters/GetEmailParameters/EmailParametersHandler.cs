using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArch.Entities.DTOs.EmailParameters;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.EmailParameters.GetEmailParameters;
internal sealed class EmailParametersHandler : IRequestHandler<GetEmailParametersDto, List<EmailParameter>>
{
    private readonly IEmailParameterRepository _emailParametersRepository;

    public EmailParametersHandler(IEmailParameterRepository emailParametersRepository)
    {
        _emailParametersRepository = emailParametersRepository;
    }

    public async Task<List<EmailParameter>> Handle(GetEmailParametersDto request, CancellationToken cancellationToken)
    {
        return await _emailParametersRepository.GetAll().Where(c => c.IsHidden == false && c.IsDeleted == false).OrderBy(c => c.Email).ToListAsync();
    }
}
