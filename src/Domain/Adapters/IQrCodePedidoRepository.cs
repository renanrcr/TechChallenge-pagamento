using Domain.Entities;

namespace Domain.Adapters
{
    public interface IQrCodePedidoRepository
    {
        Task<IList<QrCodePedido>> ObterQrCodePedidos();

        Task<QrCodePedido> ObterQrCodePorIdPedido(Guid pedidoId);

        Task<bool> InserirQrCodePedido(QrCodePedido pedido);
    }
}
