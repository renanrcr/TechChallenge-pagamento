using TechChallenge.src.Core.Domain.Adapters;
using TechChallenge.src.Core.Domain.Entities;
using TechChallenge.src.Adapters.Driven.Infra.DataContext;

namespace TechChallenge.src.Adapters.Driven.Infra.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DataBaseContext dataBaseContext)
            : base(dataBaseContext)
        {
        }
    }
}