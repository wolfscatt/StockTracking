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

            // Example Data
            builder.HasData(
                new Order { OrderId = 1, CustomerId = 1, OrderDate = new System.DateTime(2025, 1, 1), TotalAmount = 100 },
                new Order { OrderId = 2, CustomerId = 2, OrderDate = new System.DateTime(2025, 1, 2), TotalAmount = 200 },
                new Order { OrderId = 3, CustomerId = 3, OrderDate = new System.DateTime(2025, 1, 3), TotalAmount = 300 }
            );
        }
    }
}
