using MediatR;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.DTOs.EmailParameters;
public sealed record GetEmailParametersDto : IRequest<List<EmailParameter>>;