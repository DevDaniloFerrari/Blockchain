using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;
using Blockchain.Repository;

namespace Blockchain.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IQueueService _queueService;
        private readonly AppDbContext _db;

        public WalletService(IQueueService queueService, AppDbContext db)
        {
            _queueService = queueService;
            _db = db;
        }

        public void SendMoney(string from, string to, double amount)
        {
            var fromUser = _db.Users.Where(x => x.Id.ToString() == from).FirstOrDefault();
            var toUser = _db.Users.Where(x => x.Id.ToString() == to).FirstOrDefault();

            if (fromUser == null || toUser == null )
                throw new Exception("User not found.");

            if (fromUser.Balance < amount)
                throw new Exception("Balance cannot be less than amount.");

            var data = new Data(from, to, amount);

            _queueService.SendToAwaitingProcessingQueue(data);
        }
    }
}
