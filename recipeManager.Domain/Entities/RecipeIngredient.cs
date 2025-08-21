using recipeManager.Domain.Common;

namespace recipeManager.Domain.Entities;

public class RecipeIngredient: BaseEntity
{
    public string Name { get; init; } = null!;
    public string Quantity { get; init; } = null!;
    public int RecipeId { get; init; }
    public Recipe Recipe { get; init; } = null!;
}