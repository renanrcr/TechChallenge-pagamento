namespace Domain.Entities
{
    public class Pedido : EntidadeBase<Guid>
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public IList<ItemPedido> ItensPedido { get; private set; } = new List<ItemPedido>();
        public string TituloDoPedido = "Pedido Lanchonete";
        public string DescricaoDoPedido = "Pedido Aguardando Pagamento";
        public string PedidoIdString => $"{PedidoId}";
        public decimal TotalDoPedido => (ItensPedido ?? new List<ItemPedido>()).Sum(x => x.ValorTotal);

        public Pedido NewInstance(Guid pedidoId, Guid clienteId, IList<ItemPedido> itensPedido)
        {
            PedidoId = pedidoId;
            ClienteId = clienteId;
            ItensPedido = itensPedido;

            return this;
        }
    }
}
