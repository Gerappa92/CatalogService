using CatalogService.Application.Categories;
using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _dbContext;

    public CategoryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> AddAsync(Category category)
    {
        var entry = _dbContext.Add(category);
        return Task.FromResult(entry.Entity.Id);
    }

    public Task<bool> UpdateAsync(Category category)
    {
        var entry = _dbContext.Categories.Update(category);
        return Task.FromResult(entry.State == EntityState.Modified);
    }

    public Task<bool> DeleteAsync(int requestId)
    {
        var entry = _dbContext.Categories.Remove(new Category { Id = requestId });
        return Task.FromResult(entry.State == EntityState.Deleted);
    }

    public async Task<Category> GetByIdAsync(int requestId)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == requestId);
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _dbContext.Categories.ToListAsync();
    }
}