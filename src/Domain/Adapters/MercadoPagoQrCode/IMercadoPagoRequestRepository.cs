using Domain.Entities.MercadoPagoQrCode;

namespace Domain.Adapters.MercadoPagoQrCode
{
    public interface IMercadoPagoRequestRepository
    {
        Task<string?> ObterQrCode(MercadoPagoOrder orderDto);

        Task<MercadoPagoOrderStatus> ObterStatusPedido(long id);
    }
}
