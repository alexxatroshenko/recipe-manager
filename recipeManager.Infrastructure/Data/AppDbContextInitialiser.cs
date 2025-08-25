using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using recipeManager.Domain.Entities;

namespace recipeManager.Infrastructure.Data;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();

        await initialiser.InitialiseAsync();
        await initialiser.SeedAsync();
    }
}
public class AppDbContextInitialiser(AppDbContext context)
{
    public async Task InitialiseAsync()
    {
        // See https://jasontaylor.dev/ef-core-database-initialisation-strategies
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
    }

    public async Task SeedAsync()
    {
        if (!context.Recipes.Any())
        {
            context.Recipes.AddRange(
                new Recipe
                {
                    Title = "Домашние сырные палочки",
                    CookingTime = 100,
                    Tags = "закуска;легкий рецепт;к пиву",
                    Description = "Простой, но очень вкусный рецепт домашних сырных палочек. Пальчики оближешь! Минимум продуктов и максимум удовольствия, а с приготовлением справится даже ребёнок.",
                    Created = new DateTimeOffset()
                },
                new Recipe
                {
                    Title = "Картофельные драники",
                    CookingTime = 120,
                    Tags = "драники;деруны;белорусская кухня;завтрак;картофель;быстрый рецепт",
                    Description = "Очень простой и быстрый рецепт картофельных драников (дерунов).",
                    Created = new DateTimeOffset()
                },
                new Recipe
                {
                    Title = "Курица под соусом терияки",
                    CookingTime = 120,
                    Tags = "курица; терияки; вок; азия; йоу камон",
                    Description = "Простой рецепт приготовления вкусной куриной грудки на сковороде. За счёт добавления сладко-солёного соуса терияки нейтральное куриное филе приобретает интересный вкус: в нём гармонично переплетаются умеренная сладость и едва заметная острота.",
                    Created = new DateTimeOffset()
                }
                );
        }
        
        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync();
        }
    }
    
}