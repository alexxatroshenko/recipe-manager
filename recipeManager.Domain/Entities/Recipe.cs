using recipeManager.Domain.Common;

namespace recipeManager.Domain.Entities;

public class Recipe : BaseAuditableEntity
{
    public string Title { get; init; } = null!;
    public string? Description { get; init; }
    public string Instructions { get; init; } = null!;
    public int CookingTime { get; init; } // in minutes
    public int Servings { get; init; }
    public string Tags { get; init; } = null!;
    
    // Foreign key
    public int? AuthorId { get; init; }
    
    // Navigation properties
    public User Author { get; init; } = null!;
    public ICollection<RecipeLike> RecipeLikes { get; init; } = new List<RecipeLike>();
    public ICollection<RecipeComment> RecipeComments { get; init; } = new List<RecipeComment>();
    public ICollection<SavedRecipe> SavedRecipes { get; init; } = new List<SavedRecipe>();
    public ICollection<RecipeIngredient> Ingredients { get; init; } = new List<RecipeIngredient>();
    
}