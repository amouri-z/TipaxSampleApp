using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TipaxSampleApp.Models;

namespace TipaxSampleApp.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.DateOfBirth).IsRequired();
            builder.Property(c => c.PhoneNumber).IsRequired().HasColumnType("bigint").HasMaxLength(10);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.BankAccountNumber).IsRequired().HasColumnType("char").HasMaxLength(20);
        }
    }
}