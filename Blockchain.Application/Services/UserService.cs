using Blockchain.Domain.Entities;
using Blockchain.Domain.Services;
using Blockchain.Repository;

namespace Blockchain.Application.Services
{
    public class UserService : IUserService
    {
        public async Task<Guid> Create(User user)
        {
            using var context = new AppDbContext();

            await context.Users.AddAsync(user);

            await context.SaveChangesAsync();

            return user.Id;
        }
    }
}
