using RabbitMQ.Client;

namespace Domain.Adapters.RabbitMQ
{
    public interface IRabbitMqConnectionFactory
    {
        IModel GetConnectionQueuePedidoCriar();
    }
}
