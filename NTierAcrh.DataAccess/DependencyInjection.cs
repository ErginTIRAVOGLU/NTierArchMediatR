using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTierAcrh.DataAccess.Context;
using NTierAcrh.Entities.Models;
using NTierAcrh.Entities.Repositories;
using Scrutor;

namespace NTierAcrh.DataAccess;
public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("SqlServer");
        services.AddDbContext<AppDbContext>(sqlServerConfiguration =>
        {
            sqlServerConfiguration.UseSqlServer(connectionString);
        });

        //User ayarlarında Parola ile ilgili ayar yaptık numaratik karakterler istemedik
        services.AddIdentityCore<AppUser>(userConfigure =>
        {
            userConfigure.Password.RequireNonAlphanumeric = false;
        }).AddEntityFrameworkStores<AppDbContext>();

        //UnitOfWork Dependency Injection Yaptık
        services.AddScoped<IUnitOfWork>(sv => sv.GetRequiredService<AppDbContext>());
        
        //İlgili Repository lerin Dependency Injectionlarını Yaptık ama degiştirip Scrutor ile yapıyoruz
        //services.AddScoped<ICategoryRepository, CategoryRepository>();

        //Scrutor ile DependencyInjection Otomatikleştirme
        services.Scan(
                        selector =>
                        selector.FromAssemblies(
                            typeof(DependencyInjection).Assembly)
                        .AddClasses(publicOnly: false)
                        .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                        .AsMatchingInterface()
                        .WithScopedLifetime()
                    );

        return services;
    }
}