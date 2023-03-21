using CatalogService.Application.Items;
using CatalogService.Domain.Entities;

namespace CatalogService.Infrastructure.Persistence.Repositories;

public class ItemRepository : BaseRepository<Item>, IItemRepository
{
    public ItemRepository(ApplicationDbContext dbContext) : base(dbContext) { }

    public Task<bool> DeleteAsync(int id) => DeleteAsync(new Item { Id = id });
}