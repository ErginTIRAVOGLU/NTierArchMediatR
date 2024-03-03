using NTierArch.Entities.DTOs.EmailParameters;
using NTierArch.Entities.Extentions;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.Repositories;
public interface IEmailParameterRepository : IRepository<EmailParameter>
{
    Task<Result<string>> Send(SendMailDto request, CancellationToken cancellationToken);
}
