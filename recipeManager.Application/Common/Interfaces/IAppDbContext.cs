using Microsoft.EntityFrameworkCore;
using recipeManager.Domain.Entities;

namespace recipeManager.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Test> Tests { get; }
    DbSet<User> Users { get; }
    DbSet<Recipe> Recipes { get; }
    DbSet<RecipeLike> RecipeLikes { get; }
    DbSet<RecipeComment> RecipeComments { get; }
    DbSet<SavedRecipe> SavedRecipes { get; }
    DbSet<RecipeIngredient> RecipeIngredients { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}