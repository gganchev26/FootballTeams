using DnsClient.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.Configurations;
using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Repositories.MongoDb
{
    public class PlayerMongoRepository : IPlayerRepository
    {
        private readonly IMongoCollection<Players> _playersCollection;
        private readonly ILogger<PlayerMongoRepository> _logger;

        public PlayerMongoRepository(
            IOptions<MongoDbConfiguration> mongoConfig,
            ILogger<PlayerMongoRepository> logger)
        {
            _logger = logger;

            var client =
                new MongoClient(mongoConfig.Value.Connection);
            var database = client.GetDatabase(
                mongoConfig.Value.DatabaseName);
            _playersCollection = database.GetCollection<Players>("Players");
        }

        public List<Players> GetAll()
        {
            return _playersCollection.Find(m => true).ToList();
        }

        public Players? GetById(int id)
        {
            return _playersCollection.Find(m => m.Id == id).FirstOrDefault();
        }

        public void Add(Players? player)
        {
            if (player == null)
            {
                _logger.LogError("Player is null");
                return;
            }
            try
            {
                _playersCollection.InsertOne(player);
            }
            catch (Exception e) {
                _logger.LogError(e, "Failed to add a player");

            }
        }

        public void Delete(int id)
        {
            var player = GetById(id);
            if(player != null)
            {
                var filter = Builders<Players>.Filter.Eq(p => p.Id, id);
                _playersCollection.DeleteOne(filter);
            }
        }
    }
}
