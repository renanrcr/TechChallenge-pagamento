using Domain.Adapters;
using Domain.Entities;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class QrCodePedidoRepository : IQrCodePedidoRepository
    {
        private readonly IMongoCollection<QrCodePedido> _pedidoCollection;

        public QrCodePedidoRepository(IMongoDatabase mongoDatabase)
        {
            _pedidoCollection = mongoDatabase.GetCollection<QrCodePedido>("QrCodePedidos");
        }

        public async Task<IList<QrCodePedido>> ObterQrCodePedidos()
        {
            return await _pedidoCollection.Find(_ => true).ToListAsync();
        }

        public async Task<QrCodePedido> ObterQrCodePorIdPedido(Guid pedidoId)
        {
            return await _pedidoCollection.Find(_ => _.Id == pedidoId).FirstOrDefaultAsync();
        }

        public async Task<bool> InserirQrCodePedido(QrCodePedido pedido)
        {
            try
            {
                await _pedidoCollection.InsertOneAsync(pedido);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
