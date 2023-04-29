using MongoDB.Driver;
using MongoDB.Bson;
using Models;
using Microsoft.Extensions.Options;
using Repository.Interface;

namespace Services;
public class GenericRepository<T> : IGenericRepository<T> {
    private readonly IMongoCollection<T>? _genericRepository;

    public GenericRepository(IOptions<MongoDBSettings> mongoDBSettings){
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _genericRepository = database.GetCollection<T>(mongoDBSettings.Value.Collection);
    }

    public async Task<List<T>> GetAll(){
        return await _genericRepository.Find(new BsonDocument()).ToListAsync();
    }
    public async Task Add(T photo){
        await _genericRepository.InsertOneAsync(photo);
        return;
    }

    public async Task Update(string id,string photo) {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq("Id", id);
        UpdateDefinition<T> update = Builders<T>.Update.AddToSet<string>("photo", photo);

        await _genericRepository.UpdateOneAsync(filter, update);
        return;
    }

    public async Task Delete(string id) {
        FilterDefinition<T> filter = Builders<T>.Filter.Eq("Id", id);

        await _genericRepository.DeleteOneAsync(filter);
        return;
    }
}