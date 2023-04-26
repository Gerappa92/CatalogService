namespace CatalogService.Application.Categories.Dto;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Uri Image { get; set; }
    public CategoryDto Parent { get; set; }
}