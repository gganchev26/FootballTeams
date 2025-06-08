using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.Configurations;
using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Repositories.MongoDb
{
    public class TeamRepository : ITeamsRepository
    {
        private readonly IMongoCollection<Teams> _teams;

        public TeamRepository(IOptions<MongoDbConfiguration> mongoConfig)
        {
            var client = new MongoClient(mongoConfig.Value.ConnectionString);
            var database = client.GetDatabase(mongoConfig.Value.DatabaseName);
            _teams = database.GetCollection<Teams>("Teams");
        }

        public async Task<List<Teams>> GetAllTeamsFromPlayerAsync(int playerId)
        {
            var filter = Builders<Teams>.Filter.Eq(t => t.PlayerId, playerId);
            var result = await _teams.FindAsync(filter);
            return await result.ToListAsync();
        }
    }
}
