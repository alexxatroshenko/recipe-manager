using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using recipeManager.Application.Common.Interfaces;
using recipeManager.Infrastructure.Data;

namespace recipeManager.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IHostApplicationBuilder builder)
    {
        var dbName = "RecipeDb";
        var connectionString = builder.Configuration.GetConnectionString(dbName);
        if (connectionString is null) throw new ArgumentNullException($"Не найдена строка подключения для {dbName}");
        
        builder.Services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
            options.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        });
        
        builder.Services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

        builder.Services.AddScoped<AppDbContextInitialiser>();
    }
}