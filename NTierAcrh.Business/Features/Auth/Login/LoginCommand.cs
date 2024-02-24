using MediatR;

namespace NTierAcrh.Business.Features.Auth.Login;
public sealed record LoginCommand(
    string UserNameOrEmail,
    string Password,
    bool RememberMe
) : IRequest<LoginCommandResponse>;
