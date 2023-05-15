using CatalogService.Application.Items.Commands;
using CatalogService.Application.Items.Dto;
using CatalogService.Application.Items.Messages;
using CatalogService.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace CatalogService.Application.Items.Translations;

[Mapper]
public static partial class ItemTranslations 
{
    public static partial Item Map(this CreateItemCommand command);
    public static partial Item Map(this UpdateItemCommand command);
    public static partial ItemDto Map(this Item item);
    public static partial IEnumerable<ItemDto> Map(this IEnumerable<Item> items);
    public static partial ItemUpdateMessage MapToMessage(this Item item);
}