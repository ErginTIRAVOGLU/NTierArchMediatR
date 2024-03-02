using FluentValidation;
using NTierArch.Entities.DTOs.Categories;

namespace NTierArch.Business.Features.Categories.CreateCategory;
public sealed class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori adı boş olamaz!");
        RuleFor(c => c.Name).NotNull().WithMessage("Kategori adı boş olamaz!");
        RuleFor(c => c.Name).MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır!");
    }
}