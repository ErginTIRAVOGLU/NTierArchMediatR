using ErrorOr;
using MediatR;
using NTierArch.Entities.Models;

namespace NTierArch.Entities.DTOs.EmailParameters;
public record SendMailDto(
    string subject,
    string body,
    string emails
) : IRequest<ErrorOr<Unit>>;
