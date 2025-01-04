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
        }
    }
}
