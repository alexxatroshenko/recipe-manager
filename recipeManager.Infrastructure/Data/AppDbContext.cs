using System.Reflection;
using Microsoft.EntityFrameworkCore;
using recipeManager.Application.Common.Interfaces;
using recipeManager.Domain.Entities;

namespace recipeManager.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<Test> Tests => Set<Test>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<RecipeLike> RecipeLikes => Set<RecipeLike>();
    public DbSet<RecipeComment> RecipeComments => Set<RecipeComment>();
    public DbSet<SavedRecipe> SavedRecipes => Set<SavedRecipe>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}