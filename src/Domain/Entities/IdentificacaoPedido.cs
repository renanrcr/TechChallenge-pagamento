using TechChallenge.src.Core.Domain.Enums;

namespace TechChallenge.src.Core.Domain.Entities
{
    public class IdentificacaoPedido : EntidadeBase<Guid>
    {
        public string? Valor { get; private set; }
        public ETipoIdentificacaoPedido TipoIdentificacaoPedido { get; private set; }
        public Pedido? Pedido { get; private set; }
    }
}