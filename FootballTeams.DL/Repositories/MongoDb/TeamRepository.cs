using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.Configurations;
using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Repositories.MongoDb
{
    public class TeamRepository : ITeamsRepository
    {
        private IOptions<MongoDbConfiguration> _mongoConfig;
        private readonly IMongoCollection<Teams> _teams;

        public TeamRepository(IOptions<MongoDbConfiguration> mongoConfig)
        {
            _mongoConfig = mongoConfig;
            
            var client = new MongoClient(mongoConfig.Value.ConnectionString);

            var database = client.GetDatabase(mongoConfig.Value.DatabaseName);

            _teams = database.GetCollection<Teams>("Teams");
        }

        public List<Teams> GetAllTeamsFromPlayers(int playerId)
        {
            return StaticData.StaticDb.TeamsData.Where(g => g.PlayerId == playerId).ToList();
        }
    }
}
