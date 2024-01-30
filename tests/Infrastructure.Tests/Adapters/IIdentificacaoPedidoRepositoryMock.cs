using Domain.Adapters;
using Infrastructure.Repositories;
using Infrastructure.Tests.Context;

namespace Infrastructure.Tests.Adapters
{
    public class IIdentificacaoPedidoRepositoryMock
    {
        public static IIdentificacaoPedidoRepository GetMock()
        {
            var dbContext = DbContextMock.CreateDbContext();
            return new IdentificacaoPedidoRepository(dbContext);
        }
    }
}
