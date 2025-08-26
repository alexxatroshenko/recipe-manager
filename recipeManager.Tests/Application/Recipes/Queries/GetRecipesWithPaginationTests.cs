using System.Reflection;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using recipeManager.Application.Common.Interfaces;
using recipeManager.Application.Recipes.Queries;
using recipeManager.Domain.Entities;

namespace recipeManager.Tests.Application.Recipes.Queries;

public class GetRecipesWithPaginationTests
{
    [Fact]
    public void GetRecipesWithPaginationQuery_Should_Have_Correct_Properties()
    {
        // Arrange
        var pageNumber = 1;
        var pageSize = 10;

        // Act
        var query = new GetRecipesWithPaginationQuery
        {
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        // Assert
        query.PageNumber.Should().Be(pageNumber);
        query.PageSize.Should().Be(pageSize);
    }

    [Fact]
    public async Task Handle_Should_Return_Paginated_Recipes_Mapped_To_Dto()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(databaseName: $"recipes_db_{Guid.NewGuid()}")
            .Options;

        await using var context = new TestDbContext(options);

        var recipes = Enumerable.Range(1, 15).Select(i => new Recipe
        {
            Title = $"Recipe {i}",
            Description = i % 2 == 0 ? $"Desc {i}" : null,
            Instructions = $"Do {i}",
            CookingTime = 10 + i,
            Tags = i % 3 == 0 ? "fast;easy" : "easy",
            Created = DateTimeOffset.UtcNow.AddDays(-i)
        }).ToList();

        await context.Recipes.AddRangeAsync(recipes);
        await context.SaveChangesAsync(default);

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddMaps(Assembly.GetAssembly(typeof(IAppDbContext)));
        }, new LoggerFactory());
        var mapper = mapperConfig.CreateMapper();

        IAppDbContext appContext = context;
        var handler = new GetRecipesWithPagination(appContext, mapper);

        var request = new GetRecipesWithPaginationQuery { PageNumber = 2, PageSize = 5 };

        // Act
        var result = await handler.Handle(request, default);

        // Assert
        result.Should().NotBeNull();
        result.Items.Should().HaveCount(5);
        result.PageNumber.Should().Be(2);
        result.TotalPages.Should().Be(3);
        result.TotalCount.Should().Be(15);

        // Check mapping of first item on page 2 (ordered by Id)
        var firstOnPage2 = result.Items.First();
        firstOnPage2.Title.Should().Be("Recipe 6");
        firstOnPage2.Tags.Should().NotBeNull();
        firstOnPage2.Tags.Should().NotBeEmpty();
    }
}

// Minimal EF Core DbContext implementing IAppDbContext for testing
file sealed class TestDbContext : DbContext, IAppDbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

    //public DbSet<User> Users => Set<User>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<RecipeLike> RecipeLikes => Set<RecipeLike>();
    public DbSet<RecipeComment> RecipeComments => Set<RecipeComment>();
    public DbSet<SavedRecipe> SavedRecipes => Set<SavedRecipe>();
    public DbSet<RecipeIngredient> RecipeIngredients => Set<RecipeIngredient>();
}