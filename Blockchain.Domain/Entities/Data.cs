namespace Blockchain.Domain.Entities
{
    public class Data
    {
        public Data()
        {

        }
        public Data(Guid from, Guid to, decimal amout)
        {
            From = from;
            To = to;
            Amout = amout;
        }

        public Guid From { get; set; }
        public Guid To { get; set; }
        public decimal Amout { get; set; }
    }
}
