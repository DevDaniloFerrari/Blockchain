using Blockchain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blockchain.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Server=localhost;Database=blockchain;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}