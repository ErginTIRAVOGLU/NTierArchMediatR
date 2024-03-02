using FluentValidation;
using NTierArch.Entities.DTOs.Roles;

namespace NTierArch.Business.Features.Roles.UpdateRole;
public sealed class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
{
    public UpdateRoleValidator()
    {
        RuleFor(r => r.Name).NotNull().WithMessage("Rol adı boş olamaz!");
        RuleFor(r => r.Name).NotEmpty().WithMessage("Rol adı boş olamaz!");
        RuleFor(r => r.Name).MinimumLength(3).WithMessage("Rol adı en az 3 karakter olmalıdır!");
    }
}
