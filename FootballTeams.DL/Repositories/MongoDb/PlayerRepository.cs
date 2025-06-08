using FootballTeams.DL.Interfaces;
using FootballTeams.Models.Configurations;
using FootballTeams.Models.DTO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FootballTeams.DL.Repositories.MongoDb
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IMongoCollection<Players> _players;

        public PlayerRepository(IOptions<MongoDbConfiguration> mongoConfig)
        {
            var client = new MongoClient(mongoConfig.Value.ConnectionString);
            var database = client.GetDatabase(mongoConfig.Value.DatabaseName);
            _players = database.GetCollection<Players>("Players");
        }

        public async Task<List<Players>> GetAllAsync()
        {
            var allPlayers = await _players.FindAsync(FilterDefinition<Players>.Empty);
            return await allPlayers.ToListAsync();
        }

        public async Task<Players?> GetByIdAsync(int id)
        {
            var filter = Builders<Players>.Filter.Eq(p => p.Id, id);
            var result = await _players.FindAsync(filter);
            return await result.FirstOrDefaultAsync();
        }

        public async Task AddAsync(Players player)
        {
            await _players.InsertOneAsync(player);
        }

        public async Task DeleteAsync(int id)
        {
            var filter = Builders<Players>.Filter.Eq(p => p.Id, id);
            await _players.DeleteOneAsync(filter);
        }
    }
}
