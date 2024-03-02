using ErrorOr;
using MediatR;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.DTOs.EmailParameters;
public sealed record SendMailDto(
    EmailParameter emailParameter,
    string subject,
    string body,
    string emails
) : IRequest<ErrorOr<Unit>>;
