using Blockchain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blockchain.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } = null!;
    }
}