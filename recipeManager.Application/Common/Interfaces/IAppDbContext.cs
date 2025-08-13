using Microsoft.EntityFrameworkCore;
using recipeManager.Domain.Entities;

namespace recipeManager.Application.Common.Interfaces;

public interface IAppDbContext
{
    DbSet<Test> Tests { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}