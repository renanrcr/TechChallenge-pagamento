namespace Domain.Entities.MercadoPagoQrCode
{
    public class OrderItem
    {
        public string? Title { get; private set; }
        public string? Description { get; private set; }
        public decimal Unit_price { get; private set; }
        public int Quantity { get; private set; }
        public string? Unit_measure { get; private set; }
        public decimal Total_amount { get; private set; }

        public static OrderItem NewInstance(ItemPedido itemPedido)
        {
            var entidade = 
                new OrderItem
                {
                    Title = itemPedido.NomeProduto,
                    Description = itemPedido.DescricaoProduto,
                    Unit_price = itemPedido.Valor,
                    Quantity = itemPedido.Quantidade,
                    Unit_measure = itemPedido.UnidadeDeMedida,
                    Total_amount = itemPedido.ValorTotal,
                };
            
            return entidade;
        }
    }
}
