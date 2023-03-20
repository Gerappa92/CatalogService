namespace CatalogService.Application.Categories.Dtos;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Uri Image { get; set; }
    public int ParentCategoryId { get; set; }
}