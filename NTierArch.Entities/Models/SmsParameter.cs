using NTierArch.Entities.Abstractions;

namespace NTierArch.Entities.Models;
public sealed class SmsParameter : Entity
{
    public string ApiUrl { get; set; } = string.Empty;
    public string SenderNumber { get; set; } = string.Empty;
}
