using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Table name
            builder.ToTable(@"Orders", @"dbo");

            // Primary key
            builder.HasKey(o => o.OrderId);

            // Column names
            builder.Property(o => o.OrderId).HasColumnName("OrderId");
            builder.Property(o => o.CustomerId).HasColumnName("CustomerId");
            builder.Property(o => o.OrderDate).HasColumnName("OrderDate");
            builder.Property(o => o.TotalAmount).HasColumnName("TotalAmount");

            // Relationships
            builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
        }
    }
}
