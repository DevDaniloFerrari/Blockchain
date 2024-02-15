using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Blockchain.Engine
{
    public class TransactionsProcessor : BackgroundService
    {
        private readonly IBlockchainService _blockchainService;
        private readonly IQueueService _queueService;

        public TransactionsProcessor(IBlockchainService blockchainService, IQueueService queueService)
        {
            _blockchainService = blockchainService;
            _queueService = queueService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            channel.QueueDeclare(queue: "transactions",
                                durable: true,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);


            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Received message: {message}");

                ProcessTransaction(message);

                Console.WriteLine($"Processing completed for message: {message}");

                channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };
            channel.BasicConsume(queue: "transactions",
                consumer: consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }

        private void ProcessTransaction(string message)
        {
            var data = JsonConvert.DeserializeObject<Data>(message);    

            var block = _blockchainService.CreateBlock(data);

            _queueService.SendToBlocksQueue(block);
        }
      
    }
}
