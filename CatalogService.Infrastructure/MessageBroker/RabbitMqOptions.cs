namespace CatalogService.Infrastructure.MessageBroker;

public class RabbitMqOptions
{
    public const string Position = "RabbitMq";
    public string HostName { get; set; }
}