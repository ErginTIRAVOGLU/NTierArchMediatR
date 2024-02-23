using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using NTierAcrh.Business.Behaviors;
using NTierAcrh.Entities.Models;

namespace NTierAcrh.Business;
public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        //MediaTR Dependency Injection işlemi
        services.AddMediatR(cfr =>
        {
            cfr.RegisterServicesFromAssemblies(
                typeof(DependencyInjection).Assembly,
                typeof(AppUser).Assembly);
            cfr.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        //FluentValidation Dependency Injection işlemi
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        //AutoMapper Dependency Injection işlemi
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);
        return services;
    }
}
