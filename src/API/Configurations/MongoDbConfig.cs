using MongoDB.Driver;

namespace API.Configurations
{
    public static class MongoDbConfig
    {
        public static void AddMongoDb(this IServiceCollection services)
        {
            var coonectionStringMongoDB = "mongodb://mongodb:27017";
            var mongoClient = new MongoClient(coonectionStringMongoDB);
            var databaseMongoDB = mongoClient.GetDatabase("Pagamento");

            services.AddSingleton(databaseMongoDB);
        }
    }
}

