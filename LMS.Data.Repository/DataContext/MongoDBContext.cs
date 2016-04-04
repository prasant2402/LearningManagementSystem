using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.Repository
{
    public class MongoDBContext
    {
        public const string CONNECTION_STRING_NAME = "MongoDbConnection";
        public const string DATABASE_NAME = "LMSDB";

        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static MongoDBContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[CONNECTION_STRING_NAME].ConnectionString;
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name.ToLower() + "s");
        }
    }
}
