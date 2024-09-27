using api_manager_user.Models;
using Microsoft.EntityFrameworkCore;

namespace api_manager_user.Infra
{
    public class ConnectionContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public ConnectionContext(DbContextOptions<ConnectionContext> options): base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=manager_user.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.email)
                .IsUnique();
        }
    }
}
