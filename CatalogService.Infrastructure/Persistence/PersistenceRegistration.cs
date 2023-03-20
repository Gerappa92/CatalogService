using CatalogService.Application.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Infrastructure.Persistence;

public static class PersistenceRegistration
{
    public static ServiceCollection AddPersistence(this ServiceCollection services)
    {
        //TODO: Pass connection string from appsettings.json
        services.AddDbContext<ApplicationDbContext>(options =>
                       options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CatalogService;Trusted_Connection=True;",
                                                         b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

        services.AddTransient<ICategoryRepository, CategoryRepository>();
        return services;
    }
}