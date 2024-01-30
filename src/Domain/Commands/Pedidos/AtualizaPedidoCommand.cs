using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.Pedidos
{
    public class AtualizaPedidoCommand : IRequest<PedidoDTO>
    {
        public string? NumeroPedido { get; set; }
        public Guid IdentificacaoPedidoId { get; set; }
    }
}