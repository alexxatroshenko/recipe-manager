using recipeManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace recipeManager.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Username)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasIndex(u => u.Username)
            .IsUnique();

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}