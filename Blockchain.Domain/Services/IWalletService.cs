namespace Blockchain.Domain.Services
{
    public interface IWalletService
    {
        public void SendMoney(double amount, Guid userId);
    }
}
