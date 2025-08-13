using recipeManager.Domain.Common;

namespace recipeManager.Domain.Entities;

public class Test:BaseAuditableEntity
{
    public string Text { get; init; } = null!;
    public int Number { get; init; }
}