using Domain.Entities;
using MediatR;

namespace Application.Commands.QrCodes
{
    public class CadastraQrCodeCommand : IRequest<bool>
    {
        public Pedido? Pedido { get; set; }
    }
}