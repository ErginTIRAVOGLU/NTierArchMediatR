using MediatR;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.DTOs.SmsParameters;
public sealed record GetSmsParametersDto : IRequest<List<SmsParameter>>;
