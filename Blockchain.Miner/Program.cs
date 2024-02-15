using Blockchain.Domain.Entities;
using Blockchain.Repository;
using Blockchain.Shared;
using Google.Cloud.Firestore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "rabbitmq"
};

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

channel.QueueDeclare(queue: "blocks",
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);


var consumer = new EventingBasicConsumer(channel);
consumer.Received += async (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Received message: {message}");

    ProcessBlock(message).Wait();

    Console.WriteLine($"Processing completed for message: {message}");

    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
};
channel.BasicConsume(queue: "blocks",
    consumer: consumer);


async Task ProcessBlock(string message)
{
    var nonce = 0;
    var block = JsonConvert.DeserializeObject<Block>(message);

    var startTime = DateTimeOffset.UtcNow;

    while (true)
    {
        var blockHash = Helper.ComputeSha256Hash(message);
        var powHash = Helper.ComputeSha256Hash(blockHash + nonce);

        if (Helper.IsHashProofed(powHash, 1, "0"))
        {
            var totalTime = GetTotalTimeExecution(startTime);

            block.Header.Nonce = nonce;
            block.Header.BlockHash = blockHash;

            ChangeUsersAmount(block.Payload.Data);
            AddToChain(block).Wait();
            Console.WriteLine($"Mined block {block.Payload.Sequence} in {totalTime} seconds. Hash: {blockHash} ({nonce} attempts)");

            return;
        }
        nonce++;
    }
}

double GetTotalTimeExecution(DateTimeOffset startTime)
{
    var endTime = DateTimeOffset.UtcNow;
    var difference = endTime - startTime;
    return difference.TotalSeconds;
}

async Task AddToChain(Block blok)
{
    var db = FirestoreDb.Create("blockchain-b2f62");

    var documentReference = db.Collection("blockchain");
    await documentReference.AddAsync(blok);
}

async void ChangeUsersAmount(Data data)
{
    using var context = new AppDbContext();

    var fromUser = context.Users.Where(x => x.Id.ToString() == data.From).FirstOrDefault();
    var toUser = context.Users.Where(x => x.Id.ToString() == data.To).FirstOrDefault();

    if (fromUser == null || toUser == null)
        return;

    if (fromUser.Balance < data.Amount)
        return;

    fromUser.RemoveMoney(data.Amount);
    toUser.AddMoney(data.Amount);

    context.Users.Update(fromUser);
    context.Users.Update(toUser);

    context.SaveChanges();
}


Console.Read();
