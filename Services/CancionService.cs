using MusicaApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MusicaApi.Services;

public class CancionService
{
    private readonly IMongoCollection<Cancion> _cancionCollection;

    public CancionService(
        IOptions<MusicaDatabaseSettings> musicaDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            musicaDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            musicaDatabaseSettings.Value.DatabaseName);

        _cancionCollection = mongoDatabase.GetCollection<Cancion>(
            musicaDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<Cancion>> GetAsync() =>
        await _cancionCollection.Find(_ => true).ToListAsync();

    public async Task<Cancion?> GetAsync(string id) =>
        await _cancionCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Cancion newCancion) =>
        await _cancionCollection.InsertOneAsync(newCancion);

    public async Task UpdateAsync(string id, Cancion updatedCancion) =>
        await _cancionCollection.ReplaceOneAsync(x => x.Id == id, updatedCancion);

    public async Task RemoveAsync(string id) =>
        await _cancionCollection.DeleteOneAsync(x => x.Id == id);
}