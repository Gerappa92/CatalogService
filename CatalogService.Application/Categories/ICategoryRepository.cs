using CatalogService.Domain.Entities;

namespace CatalogService.Application.Categories;

public interface ICategoryRepository
{
    Task<int> AddAsync(Category category);
    Task<bool> UpdateAsync(Category category);
    Task<bool> DeleteAsync(int id);
    Task<Category> GetByIdAsync(int id);
    Task<IEnumerable<Category>> ListAsync();
}