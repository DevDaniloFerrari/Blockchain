using Blockchain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blockchain.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; } = null!;
    }
}