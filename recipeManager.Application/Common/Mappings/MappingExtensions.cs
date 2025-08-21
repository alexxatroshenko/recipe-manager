using recipeManager.Application.Common.Models;

namespace recipeManager.Application.Common.Mappings;

public static class MappingExtensions
{
    public static Task<PaginatedList<T>> PaginateListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize,
        CancellationToken cancellation = default) where T : class =>
        PaginatedList<T>.CreateAsync(source, pageNumber, pageSize, cancellation);
}