using Blockchain.Domain.Entities;

namespace Blockchain.Domain.Services
{
    public interface IUserService
    {
        public Task<Guid> Create(User user);
    }
}
