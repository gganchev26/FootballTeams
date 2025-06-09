using System.Collections.Concurrent;
using System.Text.Json;
using Confluent.Kafka;
using FootballTeams.Models.Configurations;
using FootballTeams.Models.DTO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

public class CacheConsumerService : BackgroundService
{
    private readonly KafkaConfiguration _kafkaConfig;
    public static ConcurrentDictionary<int, Players> InMemoryCache = new();

    public CacheConsumerService(IOptions<KafkaConfiguration> kafkaConfig)
    {
        _kafkaConfig = kafkaConfig.Value;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() =>
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = _kafkaConfig.BootstrapServers,
                GroupId = "cache-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            consumer.Subscribe("football-cache-topic");

            while (!stoppingToken.IsCancellationRequested)
            {
                var cr = consumer.Consume(stoppingToken);
                var player = JsonSerializer.Deserialize<Players>(cr.Message.Value);
                if (player != null)
                {
                    InMemoryCache[player.Id] = player;
                }
            }
        });
    }
}