using Aureum.Models;
using Microsoft.EntityFrameworkCore;

namespace Aureum.Data
{
    public class AureumContext : DbContext
    {
        public AureumContext(DbContextOptions<AureumContext> opts) : base(opts) { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.AccountType)
                .HasConversion<string>();

        }
    }
}
