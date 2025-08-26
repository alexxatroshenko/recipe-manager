using recipeManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace recipeManager.Infrastructure.Data.Configurations;

public class RecipeCommentConfiguration : IEntityTypeConfiguration<RecipeComment>
{
    public void Configure(EntityTypeBuilder<RecipeComment> builder)
    {
        builder.Property(rc => rc.Comment)
            .HasMaxLength(1000)
            .IsRequired();

        builder.HasOne(rc => rc.Recipe)
            .WithMany(r => r.RecipeComments)
            .HasForeignKey(rc => rc.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}