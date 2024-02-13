namespace Blockchain.Domain.Services
{
    public interface IBlockchainService
    {
        public Task CreateBlockchain();
        public object CreateBlock(object data);
    }
}
