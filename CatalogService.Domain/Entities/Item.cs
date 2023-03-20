﻿namespace CatalogService.Domain.Entities;

public class Item : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Uri Image { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Amount { get; set; }

}