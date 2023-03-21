using CatalogService.Application.Categories;
using CatalogService.Domain.Entities;

namespace CatalogService.Infrastructure.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext) { }
    public Task<bool> DeleteAsync(int id) => DeleteAsync(new Category { Id = id });
}