using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Table name
            builder.ToTable(@"Products", @"dbo");

            // Primary key
            builder.HasKey(p => p.ProductId);

            // Column names
            builder.Property(p => p.ProductId).HasColumnName("ProductId");
            builder.Property(p => p.ProductName).HasColumnName("ProductName");
            builder.Property(p => p.CategoryId).HasColumnName("CategoryId");
            builder.Property(p => p.UnitPrice).HasColumnName("UnitPrice");
            builder.Property(p => p.UnitsInStock).HasColumnName("UnitsInStock");
            builder.Property(p => p.Description).HasColumnName("Description");
            builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(p => p.PurchaseDate).HasColumnName("PurchaseDate");


            // Relationships
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);

            // Examples seed data
            builder.HasData(
                new Product
                {
                    ProductId = 1,
                    ProductName = "Product 1",
                    CategoryId = 1,
                    UnitPrice = 10,
                    UnitsInStock = 100,
                    Description = "Description 1",
                    PurchaseDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Product 2",
                    CategoryId = 2,
                    UnitPrice = 20,
                    UnitsInStock = 200,
                    Description = "Description 2",
                    PurchaseDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            );
        }
    }
}
