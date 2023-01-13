using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MonolegalApi.Models;

namespace MonolegalApi.Services
{
    public class ClientesService
    {
        private readonly IMongoCollection<Cliente> _clientesCollection;

        public ClientesService(
            IOptions<MonolegalDatabaseSettings> monolegalDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                monolegalDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                monolegalDatabaseSettings.Value.DatabaseName);

            _clientesCollection = mongoDatabase.GetCollection<Cliente>(
                monolegalDatabaseSettings.Value.ClientesCollectionName);
        }

        public async Task<List<Cliente>> GetAsync() =>
            await _clientesCollection.Find(_ => true).ToListAsync();

        public async Task<Cliente?> GetAsync(string id) =>
            await _clientesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Cliente newCliente) =>
            await _clientesCollection.InsertOneAsync(newCliente);

        public async Task UpdateAsync(string id, Cliente updatedCliente) =>
            await _clientesCollection.ReplaceOneAsync(x => x.Id == id, updatedCliente);

        public async Task RemoveAsync(string id) =>
            await _clientesCollection.DeleteOneAsync(x => x.Id == id);
    }
}
