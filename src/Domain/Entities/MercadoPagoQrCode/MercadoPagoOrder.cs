namespace Domain.Entities.MercadoPagoQrCode
{
    public class MercadoPagoOrder
    {
        public string? External_reference { get; private set; }
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public decimal Total_amount { get; private set; }
        public string? Notification_url { get; private set; }
        public IList<OrderItem>? Items { get; private set; }
        public string? Expiration_date => DateTime.Now.AddMinutes(20).ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffzzz");

        public static MercadoPagoOrder NewInstance(Pedido pedido)
        {
            var entidade = new MercadoPagoOrder
            {
                External_reference = pedido.PedidoIdString,
                Title = pedido.TituloDoPedido,
                Description = pedido.DescricaoDoPedido,
                Total_amount = pedido.TotalDoPedido,
                Items = new List<OrderItem>(pedido.ItensPedido.Select(item => OrderItem.NewInstance(item)).ToList()),
            };           

            return entidade;
        }

        public void AtualizarUrlNotificacao(string? url)
        {
            Notification_url = url;
        }
    }
}
