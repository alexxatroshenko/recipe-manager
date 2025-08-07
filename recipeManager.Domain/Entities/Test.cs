using recipeManager.Domain.Common;

namespace recipeManager.Domain.Entities;

public class Test:BaseAuditableEntity
{
    public string Text { get; set; } = null!;
    public int Number { get; set; }
}