using MediatR;
using Microsoft.EntityFrameworkCore;
using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.SmsParameters.GetSmsParameters;
internal sealed class GetSmsParametersHandler : IRequestHandler<GetSmsParametersDto, List<SmsParameter>>
{
    private readonly ISmsParameterRepository _smsParametersRepository;

    public GetSmsParametersHandler(ISmsParameterRepository smsParametersRepository)
    {
        _smsParametersRepository = smsParametersRepository;
    }

    public async Task<List<SmsParameter>> Handle(GetSmsParametersDto request, CancellationToken cancellationToken)
    {
        return await _smsParametersRepository.GetAll().Where(c => c.IsHidden == false && c.IsDeleted == false).OrderBy(c => c.SenderNumber).ToListAsync();
    }
}
