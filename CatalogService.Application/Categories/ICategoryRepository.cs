using CatalogService.Domain.Entities;

namespace CatalogService.Application.Categories;

public interface ICategoryRepository
{
    Task<int> AddAsync(Category category);
    Task<bool> UpdateAsync(Category category);
    Task<bool> DeleteAsync(int requestId);
    Task<Category> GetByIdAsync(int requestId);
    Task<IEnumerable<Category>> ListAsync();
}