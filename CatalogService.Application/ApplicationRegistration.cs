using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CatalogService.Application;

public static class ApplicationRegistration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cnf => cnf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}