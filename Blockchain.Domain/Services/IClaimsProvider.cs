namespace Blockchain.Domain.Services
{
    public interface IClaimsProvider
    {
        public ClaimsPrinciple ClaimsPrinciple { get; }
    }

    public class ClaimsPrinciple
    {
        public ClaimsPrinciple(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }
}
