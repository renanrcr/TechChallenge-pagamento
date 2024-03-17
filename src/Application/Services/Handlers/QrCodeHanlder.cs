using Application.Commands.QrCodes;
using Application.DTOs;
using Core.Application.Services;
using Domain.Adapters;
using MediatR;

namespace Application.Services.Handlers
{
    public class QrCodeHanlder : BaseService,
        IRequestHandler<QrCodeCommand, QrCodeDTO>
    {
        private readonly IQrCodePedidoRepository _qrCodePedidoRepository;

        public QrCodeHanlder(INotificador notificador,
            IQrCodePedidoRepository qrCodePedidoRepository)
            : base(notificador)
        {
            _qrCodePedidoRepository = qrCodePedidoRepository;
        }

        public async Task<QrCodeDTO> Handle(QrCodeCommand request, CancellationToken cancellationToken)
        {
            if(request.PedidoId == Guid.Empty)
            {
                Notificar("Informe um pedido.");
                return new QrCodeDTO();
            }

            var qrCodePedido = await _qrCodePedidoRepository.ObterQrCodePorIdPedido(request.PedidoId);
            if (qrCodePedido.Id != Guid.Empty)
                return QrCodeDTO.NewInstance(qrCodePedido.Id, qrCodePedido.QrCode);

            Notificar("Pedido não na base de dados.");

            return new QrCodeDTO();
        }
    }
}
