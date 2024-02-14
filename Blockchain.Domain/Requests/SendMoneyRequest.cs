namespace Blockchain.Domain.Requests
{
    public class SendMoneyRequest
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Amout { get; set; }
    }
}
