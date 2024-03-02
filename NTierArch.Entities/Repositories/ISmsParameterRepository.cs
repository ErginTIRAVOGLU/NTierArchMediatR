using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.Repositories;
public interface ISmsParameterRepository : IRepository<SmsParameter>
{
    Task Send(SendSmsDto request, CancellationToken cancellationToken);
}
