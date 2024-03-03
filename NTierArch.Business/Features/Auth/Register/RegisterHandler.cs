using MediatR;
using Microsoft.AspNetCore.Identity;
using NTierArch.Entities.DTOs.Auth;
using NTierArch.Entities.Events.Users;
using NTierArch.Entities.Extentions;
using NTierArch.Entities.Models;
using NTierArch.Entities.Repositories;

namespace NTierArch.Business.Features.Auth.Register;

internal sealed class RegisterHandler : IRequestHandler<RegisterDto, Unit>
{
    private readonly ISmsParameterRepository _smsParameterRepository;
    private readonly IEmailParameterRepository _emailParameterRepository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMediator _mediator;

    public RegisterHandler(UserManager<AppUser> userManager, IMediator mediator, ISmsParameterRepository smsParameterRepository, IEmailParameterRepository emailParameterRepository)
    {
        _userManager = userManager;
        _mediator = mediator;
        _smsParameterRepository = smsParameterRepository;
        _emailParameterRepository = emailParameterRepository;
    }

    public async Task<Unit> Handle(RegisterDto request, CancellationToken cancellationToken)
    {
        var checkUserNameExists = await _userManager.FindByNameAsync(request.UserName);
        if (checkUserNameExists is not null)
        {
            throw new ArgumentException("Bu kullanıcı adı daha önce kullanılmış!");
        }

        var checkEmailExists = await _userManager.FindByEmailAsync(request.Email);
        if (checkEmailExists is not null)
        {
            throw new ArgumentException("Bu mail adresi daha önce kullanılmış!");
        }

        if (request.Password != request.RePassword)
        {
            throw new ArgumentException("Parola ve Parola tekrarı eşleşmiyor lütfen kontrol edip tekrar deneyin!");
        }

        AppUser user = new()
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.UserName
        };

        //Aşagıda hem email hem sms gönderme kodu yazdık ama kontrol etmeye vaktim olmadı
        //var subject = "Kullanıcı Kaydı başarılı";
        //var body = "Kayıt oldunuz iyi günler.";

        //var emailDto = EmailExtension.SendEmailDto(user.Email, subject, body);

        //var smsDto = SmsExtension.SendSmsDto(user.PhoneNumber, subject, body);

        //var emailResult = _emailParameterRepository.Send(emailDto, cancellationToken);

        //var smsResult = _smsParameterRepository.Send(smsDto, cancellationToken);

        await _userManager.CreateAsync(user, request.Password);

        await _mediator.Publish(new UsersDomainEvent(user));

        return Unit.Value;
    }
}