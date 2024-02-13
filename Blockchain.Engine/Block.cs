using Newtonsoft.Json;

namespace Blockchain.Engine
{
    public class Block
    {
        public Block(int sequence, Data data)
        {
            Payload = new Payload(sequence, data);
            Header = new Header(Payload);
        }

        public Block(int sequence, Data data, string previousHash)
        {
            Payload = new Payload(sequence, data, previousHash);
            Header = new Header(Payload);
        }

        public Payload Payload { get; set; }
        public Header Header { get; set; }
    }

    public class Header
    {
        public Header(Payload payload)
        {
            BlockHash = Helper.ComputeSha256Hash(JsonConvert.SerializeObject(payload));
        }

        public int Nonce { get; set; }
        public string BlockHash { get; set; }
    }

    public class Payload
    {
        public Payload(int sequence, Data data)
        {
            Sequence = sequence;
            Timesetamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            Data = data;
            PreviousHash = string.Empty;
        }

        public Payload(int sequence, Data data, string previousHash)
        {
            Sequence = sequence;
            Timesetamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            Data = data;
            PreviousHash = previousHash;
        }

        public int Sequence { get; set; }
        public string Timesetamp { get; set; }
        public Data Data { get; set; }
        public string PreviousHash { get; set; }
    }

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
