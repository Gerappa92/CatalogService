using CatalogService.Application.Categories;
using CatalogService.Application.Items;
using CatalogService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CatalogService.Infrastructure.Persistence;

public static class PersistenceRegistration
{
    private const string UseInMemoryDatabase = "UseInMemoryDatabase";
    private const string DefaultConnection = "DefaultConnection";

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetValue<bool>(UseInMemoryDatabase))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("CleanArchitectureDb"));
        }
        else
        {
            string connectionString = configuration.GetConnectionString(DefaultConnection) ?? throw new ArgumentNullException(nameof(connectionString));
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IItemRepository, ItemRepository>();
        return services;
    }
}