using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;
using Blockchain.Repository;

namespace Blockchain.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IQueueService _queueService;

        public WalletService(IQueueService queueService)
        {
            _queueService = queueService;
        }

        public async Task SendMoney(string from, string to, double amount)
        {
            using var context = new AppDbContext();

            var fromUser = context.Users.Where(x => x.Id.ToString() == from).FirstOrDefault();
            var toUser = context.Users.Where(x => x.Id.ToString() == to).FirstOrDefault();

            if (fromUser == null || toUser == null ) 
                return;

            if (fromUser.Balance < amount)
                return;

            var data = new Data(from, to, amount);

            _queueService.SendToAwaitingProcessingQueue(data);
        }
    }
}
