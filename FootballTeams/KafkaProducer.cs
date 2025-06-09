using Confluent.Kafka;
using FootballTeams.Models.Configurations;
using Microsoft.Extensions.Options;

public class KafkaProducer
{
    private readonly IProducer<string, string> _producer;

    public KafkaProducer(IOptions<KafkaConfiguration> config)
    {
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = config.Value.BootstrapServers
        };
        _producer = new ProducerBuilder<string, string>(producerConfig).Build();
    }

    public async Task ProduceAsync(string topic, string key, string value)
    {
        await _producer.ProduceAsync(topic, new Message<string, string> { Key = key, Value = value });
    }
}