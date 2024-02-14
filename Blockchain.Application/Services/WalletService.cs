using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;

namespace Blockchain.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IQueueService _queueService;

        public WalletService(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public void SendMoney(string from, string to, double amount)
        {
            var data = new Data(from, to, amount);

            _queueService.SendToAwaitingProcessingQueue(data);
        }
    }
}
