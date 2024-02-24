using MediatR;

namespace NTierAcrh.Business.Features.Auth.Register;
public sealed record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    string Password,
    string RePassword
) : IRequest<Unit>;
