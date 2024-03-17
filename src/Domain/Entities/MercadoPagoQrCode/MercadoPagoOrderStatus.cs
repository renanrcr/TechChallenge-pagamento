namespace Domain.Entities.MercadoPagoQrCode
{
    public class MercadoPagoOrderStatus
    {
        public long Id { get; set; } = new();
        public string Status { get; set; } = string.Empty;
        public string External_reference { get; set; } = string.Empty;
    }
}
