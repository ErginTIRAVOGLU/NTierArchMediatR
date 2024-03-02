using ErrorOr;
using MediatR;

namespace NTierArch.Entities.DTOs.EmailParameters;
public sealed record DeleteEmailParameterDto(
    Guid Id
) : IRequest<ErrorOr<Unit>>;
