using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Blockchain.Infrastructure.Services
{
    public class QueueService : IQueueService
    {
        public void SendToAwaitingProcessingQueue(Data data)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(Environment.GetEnvironmentVariable("RABBITMQ_URI"))
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "transactions",
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            var json = JsonConvert.SerializeObject(data);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "transactions", body: body);
        }

        public void SendToBlocksQueue(object block)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(Environment.GetEnvironmentVariable("RABBITMQ_URI"))
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "blocks",
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            var json = JsonConvert.SerializeObject(block);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "blocks", body: body);
        }
    }
}
