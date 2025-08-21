using AutoMapper;
using recipeManager.Application.Tests.Queries;
using recipeManager.Domain.Entities;

namespace recipeManager.Application.Recipes.Queries;

public class RecipeSummaryDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public int CookingTime { get; set; }
    public List<string> Tags { get; set; } = null!;
    
    private class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Recipe, RecipeSummaryDto>()
                .ForMember(x => x.Tags, y => y.
                    MapFrom( z => z.Tags.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries).ToList()));
        }
    }
}