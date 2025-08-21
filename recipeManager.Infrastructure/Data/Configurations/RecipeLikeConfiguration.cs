using recipeManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace recipeManager.Infrastructure.Data.Configurations;

public class RecipeLikeConfiguration : IEntityTypeConfiguration<RecipeLike>
{
    public void Configure(EntityTypeBuilder<RecipeLike> builder)
    {
        builder.HasIndex(rl => new { rl.RecipeId, rl.UserId })
            .IsUnique();

        builder.HasOne(rl => rl.Recipe)
            .WithMany(r => r.RecipeLikes)
            .HasForeignKey(rl => rl.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rl => rl.User)
            .WithMany(u => u.RecipeLikes)
            .HasForeignKey(rl => rl.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}