namespace Domain.Adapters.RabbitMQ
{
    public interface IMessageServiceRepository
    {
        bool Enqueue(object message);
    }
}
