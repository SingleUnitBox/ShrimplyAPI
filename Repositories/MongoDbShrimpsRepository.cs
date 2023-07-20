using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using ShrimplyAPI.Entities;

namespace ShrimplyAPI.Repositories
{
    public class MongoDbShrimpsRepository : IShrimpsRepository
    {
        private const string databaseName = "shrimplyAPI";
        private const string collectionName = "shrimps";
        private readonly IMongoCollection<Shrimp> _shrimpsCollection;
        public MongoDbShrimpsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase("databaseName");
            _shrimpsCollection = database.GetCollection<Shrimp>(collectionName);
        }
        public void CreateShrimp(Shrimp shrimp)
        {
            _shrimpsCollection.InsertOne(shrimp);
        }

        public void DeleteShrimp(Guid id)
        {
            throw new NotImplementedException();
        }

        public Shrimp GetShrimp(Guid shrimpId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Shrimp> GetShrimps()
        {
            throw new NotImplementedException();
        }

        public void UpdateShrimp(Shrimp shrimp)
        {
            throw new NotImplementedException();
        }
    }
}