using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VentaEntradas.Application.AppServices;
using VentaEntradas.Application.Contracts;

namespace VentaEntradas.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
    {

        services.AddTransient<IEventoAppService, EventoAppService>();
 
        services.AddAutoMapper(Assembly.GetExecutingAssembly());



        return services;

    }
}