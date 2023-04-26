namespace CatalogService.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public Uri Image { get; set; }
    public int? ParentId { get; set; }

    public virtual Category Parent { get; set; }
    public virtual ICollection<Category> Children { get; set; }
}