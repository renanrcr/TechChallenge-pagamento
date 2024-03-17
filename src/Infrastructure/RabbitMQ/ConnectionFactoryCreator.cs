using RabbitMQ.Client;
using IConnectionFactory = Domain.Adapters.RabbitMQ.IConnectionFactory;

namespace Infrastructure.RabbitMQ
{
    public class ConnectionFactoryCreator : IConnectionFactory
    {
        public ConnectionFactory Get()
        {
            return new ConnectionFactory
            {
                HostName = "rabbitmq",
                Port = 5672,
                UserName = "guest",
                Password = "guest",
            };
        }
    }
}