using System.Security.Cryptography;
using System.Text;

namespace Blockchain.Engine
{
    public static class Helper
    {
        public static string ComputeSha256Hash(string rawData)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(rawData));

            var builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                builder.Append(bytes[i].ToString("x2"));

            return builder.ToString();
        }

        public static bool IsHashProofed(string hash, int difficulty, string prefix)
        {
            var value = string.Concat(Enumerable.Repeat(prefix, difficulty));
            return hash.StartsWith(value); 
        }
    }
}
