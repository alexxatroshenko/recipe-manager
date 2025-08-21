using recipeManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace recipeManager.Infrastructure.Data.Configurations;

public class SavedRecipeConfiguration : IEntityTypeConfiguration<SavedRecipe>
{
    public void Configure(EntityTypeBuilder<SavedRecipe> builder)
    {
        builder.HasIndex(sr => new { sr.RecipeId, sr.UserId })
            .IsUnique();

        builder.HasOne(sr => sr.Recipe)
            .WithMany(r => r.SavedRecipes)
            .HasForeignKey(sr => sr.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sr => sr.User)
            .WithMany(u => u.SavedRecipes)
            .HasForeignKey(sr => sr.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}