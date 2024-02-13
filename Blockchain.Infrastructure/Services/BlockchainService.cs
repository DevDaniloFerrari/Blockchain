using Blockchain.Domain.Services;
using Google.Cloud.Firestore;

namespace Blockchain.Infrastructure.Services
{
    public class BlockchainService : IBlockchainService
    {
        private readonly FirestoreDb _db;
        private Engine.Blockchain blockchain { get; set; }
        private const string Collection = "blockchain";

        public BlockchainService()
        {
            _db = FirestoreDb.Create("blockchain-b2f62");

            var query = _db.Collection(Collection).Limit(1);

            var listener = query.Listen(snapshot =>
            {
                foreach (DocumentSnapshot documentSnapshot in snapshot.Documents)
                {
                    blockchain = documentSnapshot.ConvertTo<Engine.Blockchain>();
                    Console.WriteLine(blockchain.PowPrefix);
                }
            });
        }

        public async Task CreateBlockchain()
        {
            var blockchain = new Engine.Blockchain();

            var collection = _db.Collection(Collection);

            var snapshot = await collection.Limit(1).GetSnapshotAsync();

            if (snapshot.Count == 0)
                await collection.AddAsync(blockchain);
        }

        //private async int GetNextSequence()
        //{
        //}

        //private async string GetPreviousBlockHash()
        //{
        //    return Chain.Last().Header.BlockHash;
        //}

        //public Block CreateBlock(object data)
        //{
        //    return new Block(GetNextSequence(), data, GetPreviousBlockHash());
        //}
    }
}
