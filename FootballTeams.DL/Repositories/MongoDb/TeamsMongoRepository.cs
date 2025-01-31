using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.Configurations;
using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Repositories.MongoDb
{
    public class TeamsMongoRepository : ITeamsRepository
    {
        private readonly IMongoCollection<Teams> _teamsCollection;
        private readonly ILogger<TeamsMongoRepository> _logger;

        public TeamsMongoRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<TeamsMongoRepository> logger)
        {

            _logger = logger;

            var client = new MongoClient(mongoConfig.CurrentValue.MongoDB);
            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);
            _teamsCollection = database.GetCollection<Teams>("TeamsDb");
        }
        public List<Teams> GetAll()
        {
            return _teamsCollection.Find(m => true).ToList();
        }
        public Teams? GetById(string id)
        {
            return _teamsCollection.Find(m => m.Id == id).FirstOrDefault();
        }
        public void Add(Teams? team)
        { 
            if (team == null)
            {
                _logger.LogError("Team is null");
                return;
            }
            try
            {
                _teamsCollection.InsertOne(team);
            }
            catch (Exception e) 
            {
                _logger.LogError(e, "Failed to add team");
            }
        }
        public void Update(Teams team) 
        {
            _teamsCollection.ReplaceOne(m => m.Id == team.Id, team);
        }
    }
}
