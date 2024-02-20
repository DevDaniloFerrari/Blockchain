using Blockchain.Domain.Entities;

namespace Blockchain.Domain.Services
{
    public interface IUserService
    {
        public Guid Create(User user, string password);
        public string Authenticate(string email, string password);
    }
}
