using FootballTeams.DL.Interfaces;
using FootballTeams.Models.Configurations;
using FootballTeams.Models.DTO;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FootballTeams.DL.Repositories.MongoDb
{
    public class PlayerRepository : IPlayerRepository
    {
        private IOptions<MongoDbConfiguration> _mongoConfig;
        private readonly IMongoCollection<Players> _players;

        public PlayerRepository(
            IOptions<MongoDbConfiguration> mongoConfig)
        {
            _mongoConfig = mongoConfig;
            
            var client = new MongoClient(mongoConfig.Value.ConnectionString);

            var database = client.GetDatabase(mongoConfig.Value.DatabaseName);
            _players = database.GetCollection<Players>("Players");
        }

        public List<Players> GetAll()
        {
            return StaticData.StaticDb.PlayersData;
        }

        public Players? GetById(int id)
        {
            return StaticData.StaticDb.PlayersData.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Players player)
        {
            StaticData.StaticDb.PlayersData.Add(player);
        }

        public void Delete(int id) 
        { 
            var player = GetById(id);
            if (player != null)
            {
                StaticData.StaticDb.PlayersData.Remove(player);
            }
        }
    }
}
