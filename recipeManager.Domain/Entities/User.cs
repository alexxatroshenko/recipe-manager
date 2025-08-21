using recipeManager.Domain.Common;

namespace recipeManager.Domain.Entities;

public class User : BaseAuditableEntity
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    
    // Navigation properties
    public ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    public ICollection<RecipeLike> RecipeLikes { get; set; } = new List<RecipeLike>();
    public ICollection<RecipeComment> RecipeComments { get; set; } = new List<RecipeComment>();
    public ICollection<SavedRecipe> SavedRecipes { get; set; } = new List<SavedRecipe>();
}