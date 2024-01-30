namespace TechChallenge.src.Core.Domain.Entities
{
    public class CategoriaProduto : EntidadeBase<Guid>
    {
        public string? Descricao { get; private set; }

        public Produto? Produto { get; private set; }
    }
}