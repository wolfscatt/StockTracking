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

            builder.HasData(new User
            {
                UserId = 1,
                Username = "admin",
                Password = "admin",
                FullName = "Ömer Faruk",
                Role = "Admin",
                Email = "tufar220@gmail.com",
            });
        }
    }
}
