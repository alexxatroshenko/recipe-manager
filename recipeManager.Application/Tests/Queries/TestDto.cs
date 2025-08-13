using AutoMapper;
using recipeManager.Domain.Entities;

namespace recipeManager.Application.Tests.Queries;

public class TestDto
{
    public string Text { get; init; } = null!;
    public int Number { get; init; }
    
    private class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Test, TestDto>();
        }
    }
}