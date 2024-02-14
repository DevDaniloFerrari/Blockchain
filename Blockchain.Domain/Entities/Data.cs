using Google.Cloud.Firestore;

namespace Blockchain.Domain.Entities
{
    [FirestoreData]
    public class Data
    {
        public Data()
        {

        }
        public Data(string from, string to, double amout)
        {
            From = from;
            To = to;
            Amout = amout;
        }

        [FirestoreProperty]
        public string From { get; set; }
        [FirestoreProperty]
        public string To { get; set; }
        [FirestoreProperty]
        public double Amout { get; set; }
    }
}
