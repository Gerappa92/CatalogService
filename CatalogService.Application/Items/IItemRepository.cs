using CatalogService.Domain.Entities;

namespace CatalogService.Application.Items;

public interface IItemRepository
{
    Task<int> AddAsync(Item item);
    Task<bool> UpdateAsync(Item item);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<Item>> ListAsync();
    Task<Item> GetByIdAsync(int id);
}