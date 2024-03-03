using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Extentions;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.Repositories;
public interface ISmsParameterRepository : IRepository<SmsParameter>
{
    Task<Result<string>> Send(SendSmsDto request, CancellationToken cancellationToken);
}