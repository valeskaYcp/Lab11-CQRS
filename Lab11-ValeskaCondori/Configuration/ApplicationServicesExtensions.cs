using System.Reflection;
using App.Application;

namespace Lab11_ValeskaCondori.Configuration;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Registrar MediatR buscando los Handlers en el ensamblado Application
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssemblyContaining<ApplicationAssemblyMarker>());

        // Registrar AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    }
}