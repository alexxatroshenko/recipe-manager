using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using recipeManager.Domain.Entities;

namespace recipeManager.Infrastructure.Data.Configurations;

public class RecipeIngredientConfiguration: IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);
        builder
            .Property(p => p.Quantity)
            .HasMaxLength(50);

        builder
            .HasOne(p => p.Recipe)
            .WithMany(m => m.Ingredients)
            .HasForeignKey(k => k.RecipeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}