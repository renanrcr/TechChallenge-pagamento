namespace TechChallenge.src.Core.Domain.Entities
{
    public class Produto : EntidadeBase<Guid>
    {
        public Guid CategoriaProdutoId { get; private set; }
        public string? Nome { get; private set; }
        public string? Descricao { get; private set; }
        public CategoriaProduto? CategoriaProduto { get; private set; }
        public TabelaPreco TabelaPreco { get; private set; } = new TabelaPreco();
        public ItemPedido? ItemPedido { get; private set; }
    }
}