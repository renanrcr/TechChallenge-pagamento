using Application.Commands.Webhooks;
using Core.Application.Services;
using Domain.Adapters.RabbitMQ;
using Domain.Adapters;
using MediatR;
using System.Text.Json;

namespace Application.Services.Webhooks
{
    public class FakeAtualizaStatusPagamentoHandler : BaseService,
        IRequestHandler<FakeAtualizaStatusPagamentoCommand, bool>
    {
        private readonly IMessageServiceRepository _messageServiceRepository;

        protected FakeAtualizaStatusPagamentoHandler(INotificador notificador,
            IMessageServiceRepository messageServiceRepository)
            : base(notificador)
        {
            _messageServiceRepository = messageServiceRepository;
        }

        public async Task<bool> Handle(FakeAtualizaStatusPagamentoCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != Guid.Empty)
            {
                Notificar("Informe um pedido.");
                return false;
            }

            string mensagem = JsonSerializer.Serialize(new { PedidoId = request.Id });

            if (request.Status == "closed")
            {
                _messageServiceRepository.Enqueue(mensagem);
            }
            else if (request.Status == "expired")
            {
                _messageServiceRepository.Enqueue(mensagem);
            }

            return await Task.FromResult(true);
        }
    }
}
