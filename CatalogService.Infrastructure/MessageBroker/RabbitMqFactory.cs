using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace CatalogService.Infrastructure.MessageBroker;

public class RabbitMqFactory
{
    public ConnectionFactory Factory { get; }

    public RabbitMqFactory(IOptions<RabbitMqOptions> rabbitMqOptions)
    {
        var options = rabbitMqOptions?.Value ?? throw new ArgumentNullException(nameof(rabbitMqOptions));
        Factory = new ConnectionFactory
        {
            HostName = options.HostName
        };
    }
}