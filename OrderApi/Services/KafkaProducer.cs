using Confluent.Kafka;
using Newtonsoft.Json;
using OrderApi.Model;

namespace OrderApi.Services {

    public interface IKafkaProducer {

        public Task<bool> Produce(KafkaOrderRequest order);
    }

    public class KafkaProducer : IKafkaProducer {

        public async Task<bool> Produce(KafkaOrderRequest order) {
            var config = new ProducerConfig {
                BootstrapServers = "host.docker.internal:9092",
            };

            using (var producer = new ProducerBuilder<Null, string>(config).Build()) {
                var result = await producer.ProduceAsync("weblog", new Message<Null, string> { Value = Newtonsoft.Json.JsonConvert.SerializeObject(order) });
            }

            return true;
        }
    }
}
