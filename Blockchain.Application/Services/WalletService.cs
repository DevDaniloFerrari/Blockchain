using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;
using Blockchain.Repository;

namespace Blockchain.Application.Services
{
    public class WalletService : IWalletService
    {
        private readonly IClaimsProvider _claimsProvider;
        private readonly IQueueService _queueService;
        private readonly AppDbContext _db;

        public WalletService(IClaimsProvider claimsProvider, IQueueService queueService, AppDbContext db)
        {
            _claimsProvider = claimsProvider;
            _queueService = queueService;
            _db = db;
        }

        public void SendMoney(string from, string to, double amount)
        {
            if (from == to)
                throw new Exception("You cannot send money to yourself.");

            var users = _db.Users.Where(x => x.Id.ToString() == from || x.Id.ToString() == to).ToList();

            var fromUser = users.FirstOrDefault(x => x.Id.ToString().ToUpper() == from.ToUpper());
            var toUser = users.FirstOrDefault(x => x.Id.ToString().ToUpper() == to.ToUpper());

            if (fromUser == null || toUser == null)
                throw new Exception("User not found.");

            if(fromUser.Email != _claimsProvider.ClaimsPrinciple.Email)
                throw new Exception("You do not have permission to make this transaction.");

            if (fromUser.Balance < amount)
                throw new Exception("Balance cannot be less than amount.");

            var data = new Data(from, to, amount);

            _queueService.SendToAwaitingProcessingQueue(data);
        }
    }
}
