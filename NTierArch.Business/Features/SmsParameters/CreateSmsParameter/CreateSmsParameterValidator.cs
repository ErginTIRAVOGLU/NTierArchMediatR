using FluentValidation;
using NTierArch.Entities.DTOs.SmsParameters;

namespace NTierArch.Business.Features.SmsParameters.CreateSmsParameter;
internal class UpdateEmailParameterCommandValidator : AbstractValidator<CreateSmsParameterDto>
{
    public UpdateEmailParameterCommandValidator()
    {
        RuleFor(e => e.ApiUrl).NotEmpty().WithMessage("ApiURL Boş olamaz!");
        RuleFor(e => e.ApiUrl).NotNull().WithMessage("ApiURL Boş olamaz!");
        RuleFor(e => e.ApiUrl).MinimumLength(3).WithMessage("ApiURL minimum 3 karakter olmalıdır!");


        RuleFor(e => e.SenderNumber).NotEmpty().WithMessage("Sms Numarası Boş olamaz!");
        RuleFor(e => e.SenderNumber).NotNull().WithMessage("Sms Numarası Boş olamaz!");
        RuleFor(e => e.SenderNumber).MinimumLength(11).WithMessage("Sms Numarası minimum 11 karakter olmalıdır!");
    }
}
