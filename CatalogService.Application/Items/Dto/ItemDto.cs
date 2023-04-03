namespace CatalogService.Application.Items.Dto;

public class ItemDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Uri Image { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }
}