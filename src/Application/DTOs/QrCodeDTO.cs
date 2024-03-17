namespace Application.DTOs
{
    public class QrCodeDTO
    {
        public Guid PedidoId { get; set; }
        public string? QrCode { get; set; }

        public static QrCodeDTO NewInstance(Guid pedidoId, string? qrCode)
        {
            return new QrCodeDTO { PedidoId = pedidoId, QrCode = qrCode, };
        }
    }
}
