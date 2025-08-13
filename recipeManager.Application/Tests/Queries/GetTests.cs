using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using recipeManager.Application.Common.Interfaces;

namespace recipeManager.Application.Tests.Queries;

public record GetTestsQuery : IRequest<List<TestDto>>
{
    public int Count { get; set; }
}

public class GetTestsQueryHandler(IAppDbContext context, IMapper mapper) : IRequestHandler<GetTestsQuery, List<TestDto>>
{
    public async Task<List<TestDto>> Handle(GetTestsQuery request, CancellationToken cancellationToken)
    {
        var result = await context.Tests
            .AsNoTracking()
            .Take(request.Count)
            .ProjectTo<TestDto>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
        
        return result;
    }
}