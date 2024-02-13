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
            return new Block(0, 0, new Data());
        }
    }
}
