using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Blockchain.Engine
{
    public class Processor : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "transactions",
                                durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += ConsumerReceived;
            channel.BasicConsume(queue: "transactions",
                autoAck: true,
                consumer: consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }

        private void ConsumerReceived(object sender, BasicDeliverEventArgs e)
        {
            Console.WriteLine(Encoding.UTF8.GetString(e.Body.ToArray()));
        }
    }
}
