using RabbitMQ.Client;

namespace Domain.Adapters.RabbitMQ
{
    public interface IConnectionFactory
    {
        ConnectionFactory Get();
    }
}
