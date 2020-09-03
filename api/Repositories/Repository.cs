using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using api.Model;

namespace api.Repositories {
    public class Repository<T> : IRepository<T> where T : IDocument
    {
        private MongoDbContext _context;
        private string _collectionName;
        private IMongoCollection<T> _collection;


        public Repository(string collection) {
            this._context = new MongoDbContext();
            this._collectionName = collection;

            createCollectionIfNotExist().Wait();
            this._collection = this._context.getDatabase().GetCollection<T>(this._collectionName);
        }

        public async Task<T> add(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<IList<T>> addAll(IList<T> entities)
        {
            await _collection.InsertManyAsync(entities);
            return entities;
        }

        public async Task<T> delete(T entity)
        {
            var filter = Builders<T>.Filter.Eq(e => e._id, entity._id);
            return await _collection.FindOneAndDeleteAsync(filter);
        }

        public async Task<IEnumerable<T>> findAll()
        {
            return await _collection.AsQueryable().ToListAsync();
        }

        public async Task<T> findByCodigo(string codigo)
        {
            var filter = Builders<T>.Filter.Eq(e => e.codigo, codigo);
            return await (await _collection.FindAsync(filter)).FirstOrDefaultAsync();
        }

        

        public async Task<T> update(T entity)
        {
            var filter = Builders<T>.Filter.Eq(e => e._id, entity._id);
            return await _collection.FindOneAndReplaceAsync<T>(filter, entity);
        }

        private async Task createCollectionIfNotExist() {
            if((await this._context.getDatabase().ListCollectionNamesAsync()).ToEnumerable().Any(coll => coll == this._collectionName)) {
                await this._context.getDatabase().CreateCollectionAsync(this._collectionName);
            }
        }
    }
}