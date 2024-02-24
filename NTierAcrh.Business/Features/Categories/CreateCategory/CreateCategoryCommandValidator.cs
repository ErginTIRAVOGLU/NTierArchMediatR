using FluentValidation;

namespace NTierAcrh.Business.Features.Categories.CreateCategory;
public sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Kategori adı boş olamaz!");
        RuleFor(c => c.Name).NotNull().WithMessage("Kategori adı boş olamaz!");
        RuleFor(c => c.Name).MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır!");
    }
}