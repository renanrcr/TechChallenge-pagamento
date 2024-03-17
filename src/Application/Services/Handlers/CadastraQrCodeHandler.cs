using Application.Commands.QrCodes;
using Core.Application.Services;
using Domain.Adapters.MercadoPagoQrCode;
using Domain.Adapters;
using MediatR;
using Domain.Entities.MercadoPagoQrCode;
using Domain.Entities;

namespace Application.Services.Handlers
{
    public class CadastraQrCodeHandler : BaseService,
        IRequestHandler<CadastraQrCodeCommand, bool>
    {
        private readonly IMercadoPagoRequestRepository _mercadoPagoRequestRepository;
        private readonly IQrCodePedidoRepository _qrCodePedidoRepository;

        public CadastraQrCodeHandler(INotificador notificador,
            IMercadoPagoRequestRepository mercadoPagoRequestRepository,
            IQrCodePedidoRepository qrCodePedidoRepository)
            : base(notificador)
        {
            _mercadoPagoRequestRepository = mercadoPagoRequestRepository;
            _qrCodePedidoRepository = qrCodePedidoRepository;
        }

        public async Task<bool> Handle(CadastraQrCodeCommand request, CancellationToken cancellationToken)
        {
            if (request.Pedido is null)
            {
                Notificar("Informe um pedido.");
                return false;
            }

            var mercadoPagoOrder = MercadoPagoOrder.NewInstance(request.Pedido);
            var retorno = await _mercadoPagoRequestRepository.ObterQrCode(mercadoPagoOrder);

            var pedidoQr = QrCodePedido.NewInstance(request.Pedido.Id, retorno);
            await _qrCodePedidoRepository.InserirQrCodePedido(pedidoQr);

            return true;
        }
    }
}
