
using Newtonsoft.Json;

namespace NTierArch.WebAPI.Middleware;

public class ErrorResult
{
    public string? Message { get; set; }
    public override string ToString()
    {
		return JsonConvert.SerializeObject(this);
    }
}
