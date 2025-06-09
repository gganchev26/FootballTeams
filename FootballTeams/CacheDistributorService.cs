using System.Text.Json;
using FootballTeams.Models.Configurations;
using FootballTeams.Models.DTO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class CacheDistributorService : BackgroundService
{
    private readonly KafkaProducer _producer;
    private readonly IMongoCollection<Players> _players;

    public CacheDistributorService(IOptions<MongoDbConfiguration> mongoConfig, KafkaProducer producer)
    {
        _producer = producer;
        var client = new MongoClient(mongoConfig.Value.ConnectionString);
        var db = client.GetDatabase(mongoConfig.Value.DatabaseName);
        _players = db.GetCollection<Players>("Players");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var allPlayers = await _players.Find(_ => true).ToListAsync();
            foreach (var player in allPlayers)
            {
                string json = JsonSerializer.Serialize(player);
                await _producer.ProduceAsync("football-cache-topic", player.Id.ToString(), json);
            }
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }
    }
}