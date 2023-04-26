namespace CatalogService.Web.Endpoints.Item;

public static class ItemEndpointsRegistration
{
    public const string Resource = "Items";

    public static void RegisterItemEndpoints(this WebApplication app)
    {
        var endpoints = new ItemEndpoints();
        var groupV1 = app.MapGroup($"{Api}/{Version1}/{Resource}/");
        groupV1.MapGet("list", endpoints.ListItems)
            .WithName(nameof(endpoints.ListItems))
            .WithOpenApi();
        groupV1.MapPost(string.Empty, endpoints.AddItem)
            .WithName(nameof(endpoints.AddItem))
            .WithOpenApi();
        groupV1.MapPut(string.Empty, endpoints.UpdateItem)
            .WithName(nameof(endpoints.UpdateItem))
            .WithOpenApi();
        groupV1.MapDelete("{id:int}", endpoints.DeleteItem)
            .WithName(nameof(endpoints.DeleteItem))
            .WithOpenApi();
    }
}