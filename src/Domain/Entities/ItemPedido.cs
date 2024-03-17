namespace Domain.Entities
{
    public class ItemPedido : EntidadeBase<Guid>
    {
        public string? NomeProduto { get; private set; }
        public string? DescricaoProduto { get; private set; }
        public string? UnidadeDeMedida => "unit";
        public decimal Valor { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorTotal => Valor * Quantidade;

        public ItemPedido NewInstance(string nomeProduto, string descricaoProduto, decimal valor, int quantidade)
        {
            NomeProduto = nomeProduto;
            DescricaoProduto = descricaoProduto;
            Valor = valor;
            Quantidade = quantidade;

            return this;
        }
    }
}
