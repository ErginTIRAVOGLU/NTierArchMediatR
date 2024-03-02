using NTierArch.DataAccess.Context;
using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.DataAccess.Repositories;
internal sealed class SmsParameterRepository : Repository<SmsParameter>, ISmsParameterRepository
{
    public SmsParameterRepository(AppDbContext context) : base(context)
    {
    }

    public Task Send(SendSmsDto request, CancellationToken cancellationToken)
    {
        return Task.FromResult<SmsParameter>(null);
    }
}
