using Blockchain.Domain.Entities;

namespace Blockchain.Domain.Services
{
    public interface IBlockchainService
    {
        public Task CreateBlockchain();
        public Block CreateBlock(Data data);
    }
}
