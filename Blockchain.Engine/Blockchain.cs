namespace Blockchain.Engine
{
    public class Blockchain
    {
        private IEnumerable<Block> Chain { get; set; }
        private readonly char PowPrefix = '0';

        public Blockchain()
        {
            Chain = new List<Block>
            {
                CreateGenesisBlock()
            };
        }

        private static Block CreateGenesisBlock()
        {
            return new Block(0, new Data());
        }

        private int GetNextSequence()
        {
            return Chain.Last().Payload.Sequence + 1;
        }

        private string GetPreviousBlockHash()
        {
            return Chain.Last().Header.BlockHash;
        }

        public Block CreateBlock(Data data)
        {
            return new Block(GetNextSequence(), data, GetPreviousBlockHash());
        }
    }
}
