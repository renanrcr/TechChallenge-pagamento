using Application.Commands.Webhooks;
using Core.Application.Services;
using Domain.Adapters;
using Domain.Adapters.MercadoPagoQrCode;
using Domain.Adapters.RabbitMQ;
using MediatR;
using System.Text.Json;

namespace Application.Services.Webhooks
{
    public class AtualizaStatusPagamentoHandler : BaseService,
        IRequestHandler<AtualizaStatusPagamentoCommand, bool>
    {
        private readonly IMercadoPagoRequestRepository _mercadoPagoRequestRepository;
        private readonly IMessageServiceRepository _messageServiceRepository;

        protected AtualizaStatusPagamentoHandler(INotificador notificador,
            IMercadoPagoRequestRepository mercadoPagoRequestRepository,
            IMessageServiceRepository messageServiceRepository) 
            : base(notificador)
        {
            _mercadoPagoRequestRepository = mercadoPagoRequestRepository;
            _messageServiceRepository = messageServiceRepository;
        }

        public async Task<bool> Handle(AtualizaStatusPagamentoCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != long.MinValue)
            {
                Notificar("Informe um pedido.");
                return false;
            }

            var mercadoPagoOrderStatus = await _mercadoPagoRequestRepository.ObterStatusPedido(request.Id);
            
            Guid.TryParse(mercadoPagoOrderStatus.External_reference, out Guid pedidoId);
            if (pedidoId == Guid.Empty)
            {
                Notificar("Pedido não na base de dados.");
                return false;
            }

            string mensagem = JsonSerializer.Serialize(new { PedidoId = pedidoId });

            if (mercadoPagoOrderStatus.Status == "closed")
            {
                _messageServiceRepository.Enqueue(mensagem);
            }
            else if (mercadoPagoOrderStatus.Status == "expired")
            {
                _messageServiceRepository.Enqueue(mensagem);
            }

            return true;
        }
    }
}
