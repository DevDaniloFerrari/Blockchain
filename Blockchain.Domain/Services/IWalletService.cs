namespace Blockchain.Domain.Services
{
    public interface IWalletService
    {
        public void SendMoney(Guid from, Guid to, decimal amount);
    }
}
