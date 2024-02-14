namespace Blockchain.Domain.Services
{
    public interface IWalletService
    {
        public void SendMoney(string from, string to, double amount);
    }
}
