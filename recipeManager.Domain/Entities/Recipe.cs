using recipeManager.Domain.Common;

namespace recipeManager.Domain.Entities;

public class Recipe : BaseAuditableEntity
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public string Ingredients { get; set; } = null!;
    public string Instructions { get; set; } = null!;
    public int CookingTime { get; set; } // in minutes
    public int Servings { get; set; }
    
    // Foreign key
    public int AuthorId { get; set; }
    
    // Navigation properties
    public User Author { get; set; } = null!;
    public ICollection<RecipeLike> RecipeLikes { get; set; } = new List<RecipeLike>();
    public ICollection<RecipeComment> RecipeComments { get; set; } = new List<RecipeComment>();
    public ICollection<SavedRecipe> SavedRecipes { get; set; } = new List<SavedRecipe>();
}