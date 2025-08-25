using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using recipe_manager.Infrastructure;
using recipeManager.Application.Common.Models;
using recipeManager.Application.Recipes.Queries;
namespace recipe_manager.Endpoints;

public class Recipes: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var api = app.MapGroup($"/api/{nameof(Recipes)}/");
        
        api.MapGet(GetRecipesWithPagination)
            .WithName(nameof(Recipes))
            .WithDescription("Получение списка рецептов постранично");
    }

    public async Task<Ok<PaginatedList<RecipeSummaryDto>>> GetRecipesWithPagination(ISender sender,
        [AsParameters] GetRecipesWithPaginationQuery query)
    {
        var result = await sender.Send(query);
        return TypedResults.Ok(result);
    }
}