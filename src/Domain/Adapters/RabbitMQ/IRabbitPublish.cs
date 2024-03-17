using RabbitMQ.Client;

namespace Domain.Adapters.RabbitMQ
{
    public interface IRabbitPublish
    {
        bool BasicPublishPedidoCriar(IModel channel, object messageString);
    }
}
