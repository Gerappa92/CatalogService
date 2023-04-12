namespace CatalogService.Web.Endpoints.Category;

public static class CategoryEndpointsRegistration
{
    private const string Resource = "Categories";
    public static void RegisterCategoryEndpoints(this WebApplication app)
    {
        var endpoints = new CategoryEndpoints();
        var groupV1 = app.MapGroup($"{Api}/{Version1}/{Resource}/");

        groupV1.MapGet("list", endpoints.ListCategories)
            .WithName(nameof(endpoints.ListCategories))
            .WithOpenApi();

        groupV1.MapPost(string.Empty, endpoints.AddCategory)
            .WithName(nameof(endpoints.AddCategory))
            .WithOpenApi();

        groupV1.MapPut(string.Empty, endpoints.UpdateCategory)
            .WithName(nameof(endpoints.UpdateCategory))
            .WithOpenApi();

        groupV1.MapDelete("{id:int}", endpoints.DeleteCategory)
            .WithName(nameof(endpoints.DeleteCategory))
            .WithOpenApi();
    }
}