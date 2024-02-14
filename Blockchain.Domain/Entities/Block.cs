using Blockchain.Shared;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace Blockchain.Domain.Entities
{
    [FirestoreData]
    public class Block
    {
        public Block() { }
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

        [FirestoreProperty]
        public Payload Payload { get; set; }
        [FirestoreProperty]
        public Header Header { get; set; }
    }

    [FirestoreData]
    public class Header
    {
        public Header()
        {

        }
        public Header(Payload payload)
        {
            BlockHash = Helper.ComputeSha256Hash(JsonConvert.SerializeObject(payload));
        }

        [FirestoreProperty]
        public int Nonce { get; set; }

        [FirestoreProperty]
        public string BlockHash { get; set; }
    }

    [FirestoreData]
    public class Payload
    {
        public Payload()
        {

        }
        public Payload(int sequence, Data data)
        {
            Sequence = sequence;
            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            Data = data;
            PreviousHash = string.Empty;
        }

        public Payload(int sequence, Data data, string previousHash)
        {
            Sequence = sequence;
            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString();
            Data = data;
            PreviousHash = previousHash;
        }

        [FirestoreProperty]
        public int Sequence { get; set; }

        [FirestoreProperty]
        public string Timestamp { get; set; }

        [FirestoreProperty]
        public Data Data { get; set; }

        [FirestoreProperty]
        public string PreviousHash { get; set; }
    }
}
