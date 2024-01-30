namespace TechChallenge.src.Core.Domain.Entities
{
    public class ItemPedido : EntidadeBase<Guid>
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public decimal Quantidade { get; private set; }
        public Produto Produto { get; private set; } = new Produto();
        public Pedido? Pedido { get; private set; }
    }
}