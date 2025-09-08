using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations;

public class UserConfiguration :  IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FullName).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Phone).IsRequired().HasMaxLength(32);
        builder.Property(x => x.PasswordHash).IsRequired();

        var fixedId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var fixedCreatedAt = new DateTime(2025, 09, 08, 0, 0, 0, DateTimeKind.Utc);
        
        const string precomputedHash = "$2a$12$0u7p7WbqQkq7Qx5LLuJcwu0O2b7x8rNn9wqYk4XjRj1S1mW1tq1XO";  //Admin123

        builder.HasData(new User
        {
            Id = fixedId,
            FullName = "Admin User",
            Phone = "+998901234567",
            BirthDate = new DateTime(1995, 1, 1),
            PasswordHash = precomputedHash,
            CreatedAt = fixedCreatedAt,
            UpdatedAt = null
        });
    }
}