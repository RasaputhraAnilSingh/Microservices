using MongoDB.Driver;


namespace Product.Infrastructure.MongoDB
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;
        public MongoDbService()
        {
          var client = new MongoClient(MongoDbModel.ConnectionString);
            _database = client.GetDatabase(MongoDbModel.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {

            return _database.GetCollection<T>(collectionName);
         }
    }
}
