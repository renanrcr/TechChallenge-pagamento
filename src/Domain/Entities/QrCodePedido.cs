namespace Domain.Entities
{
    public class QrCodePedido : EntidadeBase<Guid>
    {
        public string? QrCode { get; private set; }

        public static QrCodePedido NewInstance(Guid pedidoId, string? qrCode)
        {
            return new QrCodePedido { Id = pedidoId, QrCode = qrCode, DataCadastro = DateTime.Now };
        }
    }
}
