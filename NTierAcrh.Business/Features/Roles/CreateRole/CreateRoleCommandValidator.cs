using FluentValidation;

namespace NTierAcrh.Business.Features.Roles.CreateRole;
public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(r => r.Name).NotNull().WithMessage("Rol adı boş olamaz!");
        RuleFor(r => r.Name).NotEmpty().WithMessage("Rol adı boş olamaz!");
        RuleFor(r => r.Name).MinimumLength(3).WithMessage("Rol adı en az 3 karakter olmalıdır!");
    }
}
