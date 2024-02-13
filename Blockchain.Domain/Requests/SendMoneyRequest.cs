namespace Blockchain.Domain.Requests
{
    public class SendMoneyRequest
    {
        public Guid From { get; set; }
        public Guid To { get; set; }
        public decimal Amout { get; set; }
    }
}
