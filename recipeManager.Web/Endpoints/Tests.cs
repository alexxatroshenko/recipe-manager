using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using recipe_manager.Infrastructure;
using recipeManager.Application.Tests.Queries;

namespace recipe_manager.Endpoints;

public class Tests: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        var api = app.MapGroup($"/api/{nameof(Tests)}/");
        
        api.MapGet(GetTests).WithName(nameof(Tests)).WithDescription("Тестовый мето").WithGroupName("lol").WithTags("kek");
    }

    private async Task<Ok<List<TestDto>>> GetTests(ISender sender, [AsParameters] GetTestsQuery query)
    {
        var result = await sender.Send(query);

        return TypedResults.Ok(result);
    }
}