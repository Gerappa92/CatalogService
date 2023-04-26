﻿namespace CatalogService.Application.Items.Messages;

public class ItemUpdateMessage
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}