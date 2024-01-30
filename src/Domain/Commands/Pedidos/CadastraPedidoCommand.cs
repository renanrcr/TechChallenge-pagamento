using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;

namespace TechChallenge.src.Core.Domain.Commands.Pedidos
{
    public class CadastraPedidoCommand : IRequest<PedidoDTO>
    {
        public Guid IdentificacaoClienteId { get; set; }
    }
}