using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;
using Google.Cloud.Firestore;

namespace Blockchain.Infrastructure.Services
{
    public class BlockchainService : IBlockchainService
    {
        private readonly FirestoreDb _db;
        private Block _lastBlock { get; set; }
        private const string Collection = "blockchain";

        public BlockchainService()
        {
            _db = new FirestoreDbBuilder
            {
                ProjectId = Environment.GetEnvironmentVariable("FIREBASE_PROJECT_ID"),
                JsonCredentials = Environment.GetEnvironmentVariable("FIREBASE_JSON_CREDENTIALS")
            }.Build();

            var query = _db.Collection(Collection).OrderByDescending("Payload.Timestamp").Limit(1);

            var listener = query.Listen(snapshot =>
            {
                foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
                {
                    _lastBlock = documentSnapshot.ConvertTo<Block>();
                }
            });
        }

        public async Task CreateBlockchain()
        {

            var collection = _db.Collection(Collection);

            var snapshot = await collection.Limit(1).GetSnapshotAsync();

            if (snapshot.Count == 0)
            {
                var genesisBLock = CreateGenesisBlock();
                await collection.AddAsync(genesisBLock);
            }
        }

        private static Block CreateGenesisBlock()
        {
            return new Block(0, new Data());
        }

        private int GetNextSequence()
        {
            return _lastBlock.Payload.Sequence + 1;
        }

        private string GetPreviousBlockHash()
        {
            return _lastBlock.Header.BlockHash;
        }

        public Block CreateBlock(Data data)
        {
            return new Block(GetNextSequence(), data, GetPreviousBlockHash());
        }
    }
}
