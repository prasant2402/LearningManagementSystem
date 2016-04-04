using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private MongoDBContext _mongoDbContext = null;

        public Repository(MongoDBContext mongoDbContext = null)
        {
            _mongoDbContext = mongoDbContext != null ? mongoDbContext : new MongoDBContext();
        }

        private IMongoCollection<TEntity> GetCollection<T>()
        {
            return _mongoDbContext.GetCollection<TEntity>();
        }

        public async Task<Acknowledgement<TEntity>> CreateRecord(TEntity Entity)
        {
            var res = new Acknowledgement<TEntity>();
            try
            {
                var collection = GetCollection<TEntity>();
                await collection.InsertOneAsync(Entity);
                res.Success = true;
                res.Message = "Record Added Successfully...";
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.StackTrace;
                res.Success = false;
                return res;
            }
        }

        public async Task<Acknowledgement<TEntity>> UpdateRecord(string id, UpdateDefinition<TEntity> Entity)
        {
            var filter = new FilterDefinitionBuilder<TEntity>().Eq("Id", id);
            var res = new Acknowledgement<TEntity>();
            try
            {
                var collection = GetCollection<TEntity>();
                var updateResult = await collection.UpdateOneAsync(filter, Entity);
                if (updateResult.ModifiedCount < 1)
                {
                    res.Success = false;
                    res.Message = "Update Failed for entity: " + typeof(TEntity).Name;
                    return res;
                }
                res.Success = true;
                res.Message = "Successfully updated entity: " + typeof(TEntity).Name;
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.StackTrace;
                res.Success = false;
                return res;
            }  
        }

        public async Task<Acknowledgement<TEntity>> DeleteRecord(IEnumerable<string> ids)
        {
            var filter = new FilterDefinitionBuilder<TEntity>().In("Id", ids);
            var result = new Acknowledgement<TEntity>();
            try
            {
                var collection = GetCollection<TEntity>();
                var deleteRes = await collection.DeleteOneAsync(filter);
                result.Success = true;
                result.Message = "Record Deleted Successfully...";
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.StackTrace;
                result.Success = false;
                return result;
            }
        }

        public async Task<Acknowledgement<TEntity>> GetItems(IEnumerable<string> ids)
        {
            var collection = GetCollection<TEntity>();
            var res = new Acknowledgement<TEntity>();
            try
            {
                var filter = Builders<TEntity>.Filter.Eq("Id", ids);
                var entities = await collection.Find(filter).ToListAsync();
                if (entities != null)
                {
                    res.Entities = entities;
                }
                res.Success = true;
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.StackTrace;
                res.Success = false;
                return res;
            }
        }

        public async Task<Acknowledgement<TEntity>> GetAll()
        {
            var res = new Acknowledgement<TEntity>();
            try
            {
                var collection = GetCollection<TEntity>();
                var entities = await collection.Find(new BsonDocument()).ToListAsync();
                if (entities != null)
                {
                    res.Entities = entities;
                }
                res.Success = true;
                res.Message = "";
                return res;
            }
            catch (Exception ex)
            {
                res.Message = ex.StackTrace;
                res.Success = false;
                return res;
            }
        }
    }
}
