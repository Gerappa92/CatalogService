using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Infrastructure.Persistence.Repositories;

public class BaseRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext DbContext;
    protected DbSet<T> DbSet;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = DbContext.Set<T>();
    }

    public async Task<int> AddAsync(T entity)
    {
        var entry = DbSet.Add(entity);
        await DbContext.SaveChangesAsync();
        return entry.Entity.Id;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        var entry = DbSet.Update(entity);
        await DbContext.SaveChangesAsync();
        return entry.State == EntityState.Modified;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        var entry = DbSet.Remove(entity);
        await DbContext.SaveChangesAsync();
        return entry.State == EntityState.Deleted;
    }
    public async Task<T> GetByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> ListAsync()
    {
        return await DbSet.ToListAsync();
    }
}