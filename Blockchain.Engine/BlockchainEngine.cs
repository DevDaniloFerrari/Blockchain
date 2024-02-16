using Microsoft.Extensions.Hosting;
using Blockchain.Domain.Services;

namespace Blockchain.Engine
{
    public class BlockchainEngine : BackgroundService
    {
        public readonly IBlockchainService _blockchainService;

        public BlockchainEngine(IBlockchainService blockchainService)
        {
            _blockchainService = blockchainService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _blockchainService.CreateBlockchain();


            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
