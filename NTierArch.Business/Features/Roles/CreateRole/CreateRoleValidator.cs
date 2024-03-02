using FluentValidation;
using NTierArch.Entities.DTOs.Roles;

namespace NTierArch.Business.Features.Roles.CreateRole;
public sealed class CreateRoleValidator : AbstractValidator<CreateRoleDto>
{
    public CreateRoleValidator()
    {
        RuleFor(r => r.Name).NotNull().WithMessage("Rol adı boş olamaz!");
        RuleFor(r => r.Name).NotEmpty().WithMessage("Rol adı boş olamaz!");
        RuleFor(r => r.Name).MinimumLength(3).WithMessage("Rol adı en az 3 karakter olmalıdır!");
    }
}
