using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Table name
            builder.ToTable(@"Categories", @"dbo");

            // Primary key
            builder.HasKey(c => c.CategoryId);

            // Column names
            builder.Property(c => c.CategoryId).HasColumnName("CategoryId");
            builder.Property(c => c.CategoryName).HasColumnName("CategoryName");

            // Relationships
            builder.HasMany(c => c.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            // Examples seed data
            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Category 1"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Category 2"
                }
            );
        }
    }
}
