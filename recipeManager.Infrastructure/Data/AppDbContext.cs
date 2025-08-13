using System.Reflection;
using Microsoft.EntityFrameworkCore;
using recipeManager.Application.Common.Interfaces;
using recipeManager.Domain.Entities;

namespace recipeManager.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
{
    public DbSet<Test> Tests => Set<Test>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}