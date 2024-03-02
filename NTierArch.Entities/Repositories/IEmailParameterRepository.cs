using NTierArch.Entities.DTOs.EmailParameters;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.Repositories;
public interface IEmailParameterRepository : IRepository<EmailParameter>
{
    Task Send(SendMailDto request, CancellationToken cancellationToken);
}
