using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Table name
            builder.ToTable(@"Customers", @"dbo");

            // Primary key
            builder.HasKey(c => c.CustomerId);

            // Column names
            builder.Property(c => c.CustomerId).HasColumnName("CustomerId");
            builder.Property(c => c.FullName).HasColumnName("FullName");
            builder.Property(c => c.Email).HasColumnName("Email");
            builder.Property(c => c.Phone).HasColumnName("Phone");
            builder.Property(c => c.Address).HasColumnName("Address");

            // Relationships
            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Customer)
                   .HasForeignKey(o => o.CustomerId);

            // Example Data
            builder.HasData(
                new Customer()
                {
                    CustomerId = 1,
                    FullName = "Ali Veli",
                    Address = "İstanbul",
                    Email = "Test@gmail.com",
                    Phone = "1234567890",
                },
                new Customer()
                {
                    CustomerId = 2,
                    FullName = "Ahmet Mehmet",
                    Address = "Samsun",
                    Email = "Ahmet@gmail.com",
                    Phone = "5215738232",
                },
                new Customer()
                {
                    CustomerId = 3,
                    FullName = "Ayşe Fatma",
                    Address = "Ankara",
                    Email = "fatma06@gmail.com",
                    Phone = "5168944601",
                }
                );
        }
    }
}
