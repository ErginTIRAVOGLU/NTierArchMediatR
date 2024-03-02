using NTierArch.DataAccess.Context;
using NTierArch.Entities.DTOs.EmailParameters;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.DataAccess.Repositories;
internal sealed class EmailParameterRepository : Repository<EmailParameter>, IEmailParameterRepository
{
    public EmailParameterRepository(AppDbContext context) : base(context)
    {
    }

    public Task Send(SendMailDto request, CancellationToken cancellationToken)
    {
        return Task.FromResult<EmailParameter>(null);
    }
}
