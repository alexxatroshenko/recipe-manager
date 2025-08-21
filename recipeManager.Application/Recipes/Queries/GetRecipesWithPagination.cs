using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using recipeManager.Application.Common.Interfaces;
using recipeManager.Application.Common.Mappings;
using recipeManager.Application.Common.Models;

namespace recipeManager.Application.Recipes.Queries;

public record GetRecipesWithPaginationQuery : IRequest<PaginatedList<RecipeSummaryDto>>
{
    public int PageNumber { get; } = 1;
    public int PageSize { get; } = 12;
}

public class GetRecipesWithPagination: IRequestHandler<GetRecipesWithPaginationQuery, PaginatedList<RecipeSummaryDto>>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public GetRecipesWithPagination(IAppDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    
    public async Task<PaginatedList<RecipeSummaryDto>> Handle(GetRecipesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Recipes
            .OrderBy(x => x.Id)
            .ProjectTo<RecipeSummaryDto>(_mapper.ConfigurationProvider)
            .PaginateListAsync(request.PageNumber, request.PageSize, cancellationToken);
    }
}