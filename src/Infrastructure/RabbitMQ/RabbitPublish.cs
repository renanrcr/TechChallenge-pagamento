using Domain.Adapters.RabbitMQ;
using RabbitMQ.Client;
using System.Text;

namespace Infrastructure.RabbitMQ
{
    public class RabbitPublish : IRabbitPublish
    {
        public bool BasicPublishPedidoCriar(IModel channel, object messageString)
        {
            var body = Encoding.UTF8.GetBytes("server processed " + messageString);

            channel.BasicPublish(exchange: "",
                                routingKey: "pedido_criar",
                                basicProperties: null,
                                body: body);

            Console.WriteLine(" [x] Published {0} to RabbitMQ", messageString);

            return true;
        }
    }
}
