namespace NTierAcrh.Entities.Options;
public sealed class Jwt
{
    public string Audience { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string SecretKey { get; set; } = string.Empty;
}
