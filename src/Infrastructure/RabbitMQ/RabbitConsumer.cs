using Application.Commands.QrCodes;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Infrastructure.RabbitMQ
{
    internal class RabbitConsumer : BackgroundService
    {
        private readonly string _nomeDaFila;
        private IModel _channel;
        private IMediator _mediator;

        public RabbitConsumer(
            IModel model,
            IMediator mediator)
        {
            _nomeDaFila = "QueuePedidoConfirmado";
            _mediator = mediator;
            var nomeExchange = string.Empty;

            _channel = model;
            _channel.ExchangeDeclare(exchange: nomeExchange, type: ExchangeType.Fanout);
            _channel.QueueDeclare(queue: _nomeDaFila, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: _nomeDaFila, exchange: nomeExchange, routingKey: "");
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (ModuleHandle, ea) => { InvokeReceivedEvent(ModuleHandle, ea); };

            _channel.BasicConsume(queue: _nomeDaFila, autoAck: true, consumer: consumer);

            return Task.CompletedTask;
        }

        protected async void InvokeReceivedEvent(object? model, BasicDeliverEventArgs ea)
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var pedido = JsonSerializer.Deserialize<Pedido>(message);
           
            await _mediator.Send(new CadastraQrCodeCommand { Pedido = pedido, });
        }

        public override void Dispose()
        {
            if (_channel.IsOpen)
                _channel.Close();

            base.Dispose();
        }
    }
}
