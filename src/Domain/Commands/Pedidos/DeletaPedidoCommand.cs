using MediatR;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Domain.Commands.Pedidos
{
    public class DeletaPedidoCommand : IRequest<PedidoDTO>
    {
        public Guid Id { get; set; }
    }
}