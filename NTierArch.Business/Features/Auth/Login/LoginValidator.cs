using FluentValidation;
using NTierArch.Entities.DTOs.Auth;

namespace NTierArch.Business.Features.Auth.Login;
internal class LoginValidator : AbstractValidator<LoginDto>
{
    public LoginValidator()
    {
        RuleFor(u => u.UserNameOrEmail).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(u => u.UserNameOrEmail).NotNull().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(u => u.UserNameOrEmail).MinimumLength(4).WithMessage("Kullanıcı adı en az 4 karakter olmalıdır");

        RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş olamaz");
        RuleFor(u => u.Password).NotNull().WithMessage("Şifre boş olamaz");
        RuleFor(u => u.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
        RuleFor(u => u.Password).Matches("[A-Z]").WithMessage("Şifre en az 1  adet büyük harf içermeli");
        RuleFor(u => u.Password).Matches("[a-z]").WithMessage("Şifre en az 1  adet küçük harf içermeli");
        RuleFor(u => u.Password).Matches("[0-9]").WithMessage("Şifre en az 1  adet rakam içermeli");
        RuleFor(u => u.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az 1  adet özel karakter içermeli");
    }
}
