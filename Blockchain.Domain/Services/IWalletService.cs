namespace Blockchain.Domain.Services
{
    public interface IWalletService
    {
        public Task SendMoney(string from, string to, double amount);
    }
}
