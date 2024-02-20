using Blockchain.Application.Services;
using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;
using Blockchain.Repository;
using Moq;
using Moq.EntityFrameworkCore;

namespace Blockchain.Test
{
    public class WalletServiceTests
    {
        private readonly Mock<IQueueService> _queueService;

        public WalletServiceTests()
        {
            _queueService = new Mock<IQueueService>();
        }

        [Fact]
        public void WalletService_SendMoney_ShouldNotProcessWhenUsersNotFound()
        {
            var _db = new Mock<AppDbContext>();
            var users = new List<User>
            {
                new ("user 1", "email1"),
                new ("user 2", "email2"),
            };

            _db.Setup(x => x.Users)
                .ReturnsDbSet(users);

            var walletService = new WalletService(_queueService.Object, _db.Object);

            try
            {
                walletService.SendMoney("fake-id-1", "fake-id-2", 10);
            }
            catch { }

            _queueService.Verify(x => x.SendToAwaitingProcessingQueue(It.IsAny<Data>()), Times.Never);
        }

        [Fact]
        public void WalletService_SendMoney_ShouldNotProcessWhenBalanceLessThanAmout()
        {
            var user1 = new User("user 1", "email1");
            var user2 = new User("user 2", "email2");

            var _db = new Mock<AppDbContext>();
            var users = new List<User>
            {
                user1,
                user2
            };

            _db.Setup(x => x.Users)
                .ReturnsDbSet(users);

            var walletService = new WalletService(_queueService.Object, _db.Object);

            try
            {
                walletService.SendMoney(user1.Id.ToString(), user2.Id.ToString(), 10);
            }
            catch { }

            _queueService.Verify(x => x.SendToAwaitingProcessingQueue(It.IsAny<Data>()), Times.Never);
        }

        [Fact]
        public void WalletService_SendMoney_ShouldProcessWhenBalanceEqualThanAmout()
        {
            var user1 = new User("user 1", "email1");
            user1.AddMoney(10);

            var user2 = new User("user 2", "email2");

            var _db = new Mock<AppDbContext>();
            var users = new List<User>
            {
                user1,
                user2
            };

            _db.Setup(x => x.Users)
                .ReturnsDbSet(users);

            var walletService = new WalletService(_queueService.Object, _db.Object);

            walletService.SendMoney(user1.Id.ToString(), user2.Id.ToString(), 10);

            _queueService.Verify(x => x.SendToAwaitingProcessingQueue(It.IsAny<Data>()), Times.Once);
        }
    }
}