using System.Text;
using System.Text.Json;
using CatalogService.Application;
using RabbitMQ.Client;

namespace CatalogService.Infrastructure.MessageBroker;

public class RabbitMq<T> : IMessageBroker<T> where T : class
{
    private readonly ConnectionFactory _factory;


    public RabbitMq(RabbitMqFactory rabbitMqFactory)
    {
        _factory = rabbitMqFactory.Factory;
    }

    public void Send(T message)
    {
        using var connection = _factory.CreateConnection();
        using var channel = connection.CreateModel();
        
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        channel.BasicPublish(exchange: "CatalogService-ItemUpdate-Exchange", routingKey: "", basicProperties: null, body: body);
    }
}