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
        if (!context.Tests.Any())
        {
            context.Tests.Add(new Test
            {
                Text = "Test text",
                Number = 999
            });
        
            await context.SaveChangesAsync();
        }
    }
    
}