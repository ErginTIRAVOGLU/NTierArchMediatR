using FluentValidation;
using NTierArch.Entities.DTOs.EmailParameters;

namespace NTierArch.Business.Features.EmailParameters.UpdateEmailParameter;
internal class UpdateEmailParameterValidator : AbstractValidator<UpdateEmailParameterDto>
{
    public UpdateEmailParameterValidator()
    {
        RuleFor(e => e.Smtp).NotEmpty().WithMessage("Smtp Boş olamaz!");
        RuleFor(e => e.Smtp).NotNull().WithMessage("Smtp Boş olamaz!");
        RuleFor(e => e.Smtp).MinimumLength(4).WithMessage("Smtp minimum 3 karakter olmalıdır!");

        RuleFor(e => e.Email).NotEmpty().WithMessage("Email Boş olamaz!");
        RuleFor(e => e.Email).NotNull().WithMessage("Email Boş olamaz!");
        RuleFor(e => e.Email).MinimumLength(3).WithMessage("Email minimum 3 karakter olmalıdır!");
        RuleFor(e => e.Email).EmailAddress().WithMessage("Geçerli bir email adresi girin!");


        RuleFor(e => e.Password).NotEmpty().WithMessage("Şifre Boş olamaz!");
        RuleFor(e => e.Password).NotNull().WithMessage("Şifre Boş olamaz!");
        //RuleFor(e => e.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
        //RuleFor(e => e.Password).Matches("[A-Z]").WithMessage("Şifre en az 1 adet büyük harf içermelidir");
        //RuleFor(e => e.Password).Matches("[a-z]").WithMessage("Şifre en az 1 adet küçük harf içermelidir");
        //RuleFor(e => e.Password).Matches("[0-9]").WithMessage("Şifre en az 1 adet sayı içermelidir");
        //RuleFor(e => e.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az 1 adet özel karakter içermelidir");


        RuleFor(e => e.Port).NotEmpty().WithMessage("Port Boş olamaz!");
        RuleFor(e => e.Port).NotNull().WithMessage("Port Boş olamaz!");
        RuleFor(e => e.Port).MinimumLength(3).WithMessage("Port minimum 3 karakter olmalıdır!");


        RuleFor(e => e.SSL).NotEmpty().WithMessage("SSL Boş olamaz!");
        RuleFor(e => e.SSL).NotNull().WithMessage("SSL Boş olamaz!");
    }
}
