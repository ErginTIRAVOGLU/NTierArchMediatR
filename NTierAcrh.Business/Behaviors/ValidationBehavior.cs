using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace NTierAcrh.Business.Behaviors;

// ValidationBehavior adlı sealed (mühürlü) sınıf, IPipelineBehavior arayüzünü uygular ve generic parametreleri alırız.
public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TRequest>, IRequest
{

    // Sınıf içinde kullanılacak doğrulama nesnelerini içeren bir koleksiyon.
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    // Constructor (yapıcı metot) ile doğrulama nesnelerini parametre olarak aldık.
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    // MediatR tarafından tanımlanan IPipelineBehavior arayüzünün Handle metodu uyguladık.
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // Eğer doğrulama nesneleri yoksa, işlemi devam ettirir.
        if (!_validators.Any())
        {
            return await next();
        }

        // Doğrulama bağlamını oluşturduk.
        var context = new ValidationContext<TRequest>(request);

        // Doğrulama nesneleri ile isteği doğruladık ve hataları bir sözlük yapısına dönüştürdük.
        var errorDictionary = _validators
            .Select(s => s.Validate(context))
            .SelectMany(s => s.Errors)
            .Where(s => s != null)
            .GroupBy(
                s => s.PropertyName,
                s => s.ErrorMessage, (propertyName, errorMessage) => new
                {
                    Key = propertyName,
                    Values = errorMessage.Distinct().ToArray()
                }
            )
            .ToDictionary(s => s.Key, s => s.Values[0]);

        // Eğer hata varsa, hataları bir ValidationException ile fırlattık.
        if (errorDictionary.Any())
        {
            var errors = errorDictionary.Select(s => new ValidationFailure
            {
                PropertyName = s.Value,
                ErrorCode = s.Key
            });

            throw new ValidationException(errors);
        }

        // Hata yoksa, işlemi devam ettirdik.
        return await next();
    }
}
