using FluentValidation;
using NTierArch.Entities.DTOs.Auth;

namespace NTierArch.Business.Features.Auth.Register;
public sealed class RegisterValidator : AbstractValidator<RegisterDto>
{
    public RegisterValidator()
    {
        RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim boş olamaz");
        RuleFor(u => u.FirstName).NotNull().WithMessage("İsim boş olamaz");
        RuleFor(u => u.FirstName).MinimumLength(2).WithMessage("İsim az 2 karakter olmalıdır");

        RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim boş olamaz");
        RuleFor(u => u.LastName).NotNull().WithMessage("Soyisim boş olamaz");
        RuleFor(u => u.LastName).MinimumLength(2).WithMessage("Soyisim en az 2 karakter olmalıdır");

        RuleFor(u => u.Email).NotEmpty().WithMessage("Mail adresi boş olamaz");
        RuleFor(u => u.Email).NotNull().WithMessage("Mail adresi boş olamaz");
        RuleFor(u => u.Email).MinimumLength(3).WithMessage("Mail adresi en az 3 karakter olmalıdır");
        RuleFor(u => u.Email).EmailAddress().WithMessage("Geçerli bir mail adresi yazın");

        RuleFor(u => u.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(u => u.UserName).NotNull().WithMessage("Kullanıcı adı boş olamaz");
        RuleFor(u => u.UserName).MinimumLength(4).WithMessage("Kullanıcı adı en az 4 karakter olmalıdır");

        RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş olamaz");
        RuleFor(u => u.Password).NotNull().WithMessage("Şifre boş olamaz");
        RuleFor(u => u.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
        RuleFor(u => u.Password).Matches("[A-Z]").WithMessage("Şifre en az 1  adet büyük harf içermeli");
        RuleFor(u => u.Password).Matches("[a-z]").WithMessage("Şifre en az 1  adet küçük harf içermeli");
        RuleFor(u => u.Password).Matches("[0-9]").WithMessage("Şifre en az 1  adet rakam içermeli");
        RuleFor(u => u.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az 1  adet özel karakter içermeli");

        RuleFor(u => u.RePassword).NotEmpty().WithMessage("Şifre tekrarı boş olamaz");
        RuleFor(u => u.RePassword).NotNull().WithMessage("Şifre tekrarı boş olamaz");
        RuleFor(u => u.RePassword).MinimumLength(6).WithMessage("Şifre tekrarı en az 6 karakter olmalıdır");
        RuleFor(u => u.RePassword).Matches("[A-Z]").WithMessage("Şifre tekrarı en az 1  adet büyük harf içermeli");
        RuleFor(u => u.RePassword).Matches("[a-z]").WithMessage("Şifre tekrarı en az 1  adet küçük harf içermeli");
        RuleFor(u => u.RePassword).Matches("[0-9]").WithMessage("Şifre tekrarı en az 1  adet rakam içermeli");
        RuleFor(u => u.RePassword).Matches("[^a-zA-Z0-9]").WithMessage("Şifre tekrarı en az 1  adet özel karakter içermeli");
    }
}
