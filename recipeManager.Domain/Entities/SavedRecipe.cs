using recipeManager.Domain.Common;

namespace recipeManager.Domain.Entities;

public class SavedRecipe : BaseAuditableEntity
{
    // Foreign keys
    public int RecipeId { get; set; }
    public int UserId { get; set; }
    
    // Navigation properties
    public Recipe Recipe { get; set; } = null!;
    public User User { get; set; } = null!;
}