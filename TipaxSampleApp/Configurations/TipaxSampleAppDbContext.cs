using Microsoft.EntityFrameworkCore;
using TipaxSampleApp.Models;

namespace TipaxSampleApp.Configurations
{
    public class TipaxSampleAppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public TipaxSampleAppDbContext(DbContextOptions<TipaxSampleAppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasIndex(e => e.Email).IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(e => new { e.FirstName, e.LastName, e.DateOfBirth }).IsUnique();

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}