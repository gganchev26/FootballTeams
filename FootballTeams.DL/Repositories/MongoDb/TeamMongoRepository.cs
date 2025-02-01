using FootballTeams.DL.Interfaces;
using FootballTeams.Models.Configurations;
using FootballTeams.Models.DTO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FootballTeams.DL.Repositories.MongoDb
{
    public class TeamMongoRepository : ITeamsRepository
    {
            private readonly IMongoCollection<Teams> _teamsCollection;
            private readonly ILogger<TeamMongoRepository> _logger;

            public TeamMongoRepository(
                IOptions<MongoDbConfiguration> mongoConfig,
                ILogger<TeamMongoRepository> logger)
            {
                _logger = logger;

                var client =
                    new MongoClient(mongoConfig.Value.ConnectionString);
                var database = client.GetDatabase(
                    mongoConfig.Value.DatabaseName);
                _teamsCollection = database.GetCollection<Teams>("Teams");
            }

        public List<Teams> GetTeamByPlacement(int placement)
        {
            return _teamsCollection.Find(m => m.Placement == placement).ToList();
        }
    }
}
