using CatalogService.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Infrastructure.MessageBroker;

public static class MessageBrokerRegistration
{
    public static void AddMessageBroker(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<RabbitMqOptions>(config.GetSection(RabbitMqOptions.Position));
        services.AddSingleton<RabbitMqFactory>();
        services.AddTransient(typeof(IMessageBroker<>), typeof(RabbitMq<>));
    }
}