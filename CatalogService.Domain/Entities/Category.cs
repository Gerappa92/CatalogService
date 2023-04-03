namespace CatalogService.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public Uri Image { get; set; }
    public Category Parent { get; set; }
}