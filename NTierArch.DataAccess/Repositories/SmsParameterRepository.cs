using System.Text;
using MediatR;
using NTierArch.DataAccess.Context;
using NTierArch.Entities.DTOs.SmsParameters;
using NTierArch.Entities.Extentions;
using NTierArch.Entities.Models;
using NTierArch.Entities.Notifications;
using NTierArch.Entities.Repositories;

namespace NTierArch.DataAccess.Repositories;
internal sealed class SmsParameterRepository : Repository<SmsParameter>, ISmsParameterRepository
{
    private readonly ISmsParameterRepository _smsParameterRepository;
    private readonly HttpClient _httpClient;
    private readonly IMediator _mediator;
    public SmsParameterRepository(AppDbContext context, HttpClient httpClient, IMediator mediator, ISmsParameterRepository smsParameterRepository) : base(context)
    {
        _httpClient = httpClient;
        _mediator = mediator;
        _smsParameterRepository = smsParameterRepository;
    }

    public async Task<Result<string>> Send(SendSmsDto request, CancellationToken cancellationToken)
    {
        var smsParameter = await _smsParameterRepository.GetFirst();
        var apiUrl = smsParameter.ApiUrl;

        var content = new StringContent($"To={request.toNumbers}&Message={request.body}", Encoding.UTF8, "application/x-www-form-urlencoded");

        var response = await _httpClient.PostAsync(apiUrl, content, cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = $"SMS gönderme başarısız. HTTP Hata Kodu: {response.StatusCode}";
            return await Task.FromResult(Result<string>.Failure(errorMessage));
        }

        await _mediator.Send(new SmsSendNotification(smsParameter, request));
        return await Task.FromResult(Result<string>.Succeed("SMS başarıyla gönderildi"));
    }
}
