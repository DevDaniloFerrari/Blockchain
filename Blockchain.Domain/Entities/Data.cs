using Google.Cloud.Firestore;

namespace Blockchain.Domain.Entities
{
    [FirestoreData]
    public class Data
    {
        public Data()
        {

        }
        public Data(string from, string to, double amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }

        [FirestoreProperty]
        public string From { get; set; }
        [FirestoreProperty]
        public string To { get; set; }
        [FirestoreProperty]
        public double Amount { get; set; }
    }
}
