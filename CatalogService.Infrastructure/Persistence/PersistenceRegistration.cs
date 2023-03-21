using CatalogService.Application.Categories;
using CatalogService.Application.Items;
using CatalogService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CatalogService.Infrastructure.Persistence;

public static class PersistenceRegistration
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException(nameof(connectionString));
        services.AddDbContext<ApplicationDbContext>(options =>
                       options.UseSqlServer(connectionString
                           , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IItemRepository, ItemRepository>();
        return services;
    }
}