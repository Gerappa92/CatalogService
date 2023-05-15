namespace CatalogService.Application;

public interface IMessageBroker<in T> where T : class
{
    void Send(T message);
}