using Domain.Adapters;
using Infrastructure.Repositories;
using Infrastructure.Tests.Context;

namespace Infrastructure.Tests.Adapters
{
    public class IPedidoRepositoryMock
    {
        public static IPedidoRepository GetMock()
        {
            var dbContext = DbContextMock.CreateDbContext();
            return new PedidoRepository(dbContext);
        }
    }
}
