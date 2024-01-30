using Domain.Adapters;
using Infrastructure.Repositories;
using Infrastructure.Tests.Context;

namespace Infrastructure.Tests.Adapters
{
    public class IProdutoRepositoryMock
    {
        public static IProdutoRepository GetMock()
        {
            var dbContext = DbContextMock.CreateDbContext();
            return new ProdutoRepository(dbContext);
        }
    }
}
