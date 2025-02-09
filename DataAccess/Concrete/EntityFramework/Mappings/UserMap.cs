using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table name
            builder.ToTable(@"Users", @"dbo");

            // Primary key
            builder.HasKey(u => u.UserId);

            // Column names
            builder.Property(u => u.UserId).HasColumnName("UserId");
            builder.Property(u => u.Username).HasColumnName("Username");
            builder.Property(u => u.Password).HasColumnName("Password");
            builder.Property(u => u.FullName).HasColumnName("FullName");
            builder.Property(u => u.Role).HasColumnName("Role");
            builder.Property(u => u.Email).HasColumnName("Email");
            builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
