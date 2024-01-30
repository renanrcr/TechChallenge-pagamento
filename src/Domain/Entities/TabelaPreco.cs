namespace TechChallenge.src.Core.Domain.Entities
{
    public class TabelaPreco : EntidadeBase<Guid>
    {
        public Guid ProdutoId { get; set; }
        public decimal Preco { get; private set; }
        public Produto? Produto { get; private set; }
    }
}