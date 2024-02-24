namespace NTierAcrh.Business.Features.Auth.Login;
public sealed record LoginCommandResponse(
    string AccessToken,
    Guid UserId
);