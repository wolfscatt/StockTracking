using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            // Table name
            builder.ToTable(@"OrderDetails", @"dbo");

            // Primary key
            builder.HasKey(od => od.OrderDetailId);

            // Column names
            builder.Property(od => od.OrderDetailId).HasColumnName("OrderDetailId");
            builder.Property(od => od.OrderId).HasColumnName("OrderId");
            builder.Property(od => od.ProductId).HasColumnName("ProductId");
            builder.Property(od => od.Quantity).HasColumnName("Quantity");
            builder.Property(od => od.UnitPrice).HasColumnName("UnitPrice");

            // Relationships
            builder.HasOne(od => od.Order).WithMany(o => o.OrderDetails).HasForeignKey(od => od.OrderId);
            builder.HasOne(od => od.Product).WithMany().HasForeignKey(od => od.ProductId);

            // Example Data
            builder.HasData(
                new OrderDetail { OrderDetailId = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 100 },
                new OrderDetail { OrderDetailId = 2, OrderId = 2, ProductId = 2, Quantity = 2, UnitPrice = 200 },
                new OrderDetail { OrderDetailId = 3, OrderId = 3, ProductId = 30, Quantity = 3, UnitPrice = 300 }
            );
        }
    }
}
