using FluentValidation;

namespace NTierAcrh.Business.Features.Products.UpdateProduct;
public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Ürün adı boş olamaz!");
        RuleFor(c => c.Name).NotNull().WithMessage("Ürün adı boş olamaz!");
        RuleFor(c => c.Name).MinimumLength(3).WithMessage("Ürün adı en az 3 karakter olmalıdır!");
        RuleFor(p => p.CategoryId).NotNull().WithMessage("Ürün kategorisi boş olamaz");
        RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Ürün kategorisi boş olamaz");
        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Ürün fiyatı 0 olamaz");
        RuleFor(p => p.Quantity).GreaterThan(0).WithMessage("Adet 0 olamaz");
    }
}
