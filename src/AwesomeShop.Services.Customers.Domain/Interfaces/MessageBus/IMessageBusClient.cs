namespace AwesomeShop.Services.Customers.Domain.Interfaces.MessageBus
{
    public interface IMessageBusClient
    {
        void Publish(object message, string routingKey, string exchange);
    }
}