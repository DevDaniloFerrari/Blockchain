using Blockchain.Shared;

namespace Blockchain.Domain.Entities
{
    public class User
    {
        private readonly int _iteration = 3;

        public User(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public double Balance { get; private set; }

        public void SetPassword(string password)
        {
            PasswordSalt = PasswordHasher.GenerateSalt();
            PasswordHash = PasswordHasher.ComputeHash(password, PasswordSalt, Environment.GetEnvironmentVariable("PASSWORD_PEPPER"), _iteration);
        }

        public void AddMoney(double amount)
        {
            Balance += amount;
        }

        public void RemoveMoney(double amount)
        {
            Balance -= amount;
        }
    }
}
