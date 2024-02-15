using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;
using Blockchain.Repository;

namespace Blockchain.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
        public UserService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<Guid> Create(User user)
        {
            await _db.Users.AddAsync(user);

            await _db.SaveChangesAsync();

            return user.Id;
        }
    }
}
