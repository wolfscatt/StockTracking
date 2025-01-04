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
        }
    }
}
