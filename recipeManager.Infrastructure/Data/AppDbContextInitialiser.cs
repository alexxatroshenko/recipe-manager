using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using recipeManager.Application.Common.Interfaces;

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
public class AppDbContextInitialiser
{
    private readonly AppDbContext _context;

    public AppDbContextInitialiser(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task InitialiseAsync()
    {
        // See https://jasontaylor.dev/ef-core-database-initialisation-strategies
        await _context.Database.EnsureDeletedAsync();
        await _context.Database.EnsureCreatedAsync();
    }

    public async Task SeedAsync()
    {
        // if (!_context.TodoLists.Any())
        // {
        //     _context.TodoLists.Add(new TodoList
        //     {
        //         Title = "Todo List",
        //         Items =
        //         {
        //             new TodoItem { Title = "Make a todo list 📃" },
        //             new TodoItem { Title = "Check off the first item ✅" },
        //             new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
        //             new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
        //         }
        //     });
        //
        //     await _context.SaveChangesAsync();
        // }
    }
    
}