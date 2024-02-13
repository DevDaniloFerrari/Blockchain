namespace Blockchain.Engine
{
    public class Block
    {
        public Header Header { get; set; }
        public Payload Payload { get; set; }
    }

    public class Header
    {
        public int Nonce { get; set; }
        public string BlockHash { get; set; }
    }

    public class Payload
    {
        public int Sequence { get; set; }
        public int Timesetamp { get; set; }
        public Data Data { get; set; }
        public string PreviousHash { get; set; }
    }

    public class Data
    {
        public Guid From { get; set; }
        public Guid To { get; set; }
        public decimal Amout { get; set; }
    }

}
