using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Tests.Context
{
    public class DbContextMock
    {
        public static DataBaseContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<DataBaseContext>()
                .UseInMemoryDatabase(databaseName: "DataBaseTests")
                .Options;

            var dbContext = new DataBaseContext(options);

            return dbContext;
        }
    }
}
