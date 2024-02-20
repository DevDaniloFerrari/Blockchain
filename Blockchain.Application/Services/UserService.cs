using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;
using Blockchain.Repository;
using Blockchain.Shared;
using Blockchain.Infrastructure.Services;

namespace Blockchain.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        private readonly int _iteration = 3;

        public UserService(AppDbContext db)
        {
            _db = db;
        }

        public string Authenticate(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(x => x.Email == email) ?? throw new Exception("Username or password did not match.");
            
            var passwordHash = PasswordHasher.ComputeHash(password, user.PasswordSalt, Environment.GetEnvironmentVariable("PASSWORD_PEPPER"), _iteration);
            if (user.PasswordHash != passwordHash)
                throw new Exception("Username or password did not match.");

            return TokenService.GenerateToken(user);
        }

        public Guid Create(User user, string password)
        {
            user.SetPassword(password);

            _db.Users.Add(user);

            _db.SaveChanges();

            return user.Id;
        }
    }
}
