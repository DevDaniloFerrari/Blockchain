using Google.Cloud.Firestore;

namespace Blockchain.Engine
{
    [FirestoreData]
    public class Blockchain
    {
        [FirestoreProperty]
        public IEnumerable<Block> Chain { get; private set; }
        [FirestoreProperty]
        public string PowPrefix { get; private set; }

        public Blockchain()
        {
            Chain = new List<Block>
            {
                CreateGenesisBlock()
            };

            PowPrefix = "0";
        }

        private static Block CreateGenesisBlock()
        {
            return new Block(0, new {});
        }
    }
}
