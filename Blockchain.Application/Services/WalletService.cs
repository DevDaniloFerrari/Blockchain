using Blockchain.Domain.Services;
using Blockchain.Engine;

namespace Blockchain.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IQueueService _queueService;

        public WalletService(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public void SendMoney(Guid from, Guid to, decimal amount)
        {
            var data = new Data(from, to, amount);

            _queueService.SendToAwaitingProcessingQueue(data);
        }
    }
}
