using Microsoft.Extensions.DependencyInjection;

namespace NTierAcrh.Business;
public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddMediatR(cfr =>
        {
            cfr.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        return services;
    }
}
