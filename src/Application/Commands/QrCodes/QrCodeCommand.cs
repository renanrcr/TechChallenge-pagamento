using Application.DTOs;
using MediatR;

namespace Application.Commands.QrCodes
{
    public class QrCodeCommand : IRequest<QrCodeDTO>
    {
        public Guid PedidoId { get; set; }
    }
}
