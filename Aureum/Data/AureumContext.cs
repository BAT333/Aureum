using Aureum.Models;
using Microsoft.EntityFrameworkCore;

namespace Aureum.Data
{
    public class AureumContext : DbContext
    {
        public AureumContext(DbContextOptions<AureumContext> opts) : base(opts) { }

        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Account> Accounts { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.AccountType)
                .HasConversion<string>();


            modelBuilder.Entity<Account>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            /*
            modelBuilder.Entity<Invoice>().HasKey(i => new { i.UserId, i.IdMonthYear });

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Invoice)
                .WithMany(i => i.Accounts)
                .HasForeignKey(a => new { a.InvoiceUserId, a.InvoiceIdMonthYear })
                .OnDelete(DeleteBehavior.Cascade);
            */

            base.OnModelCreating(modelBuilder);

        }
    }
}
