using AutoMapper;
using CatalogService.Application.Items.Dto;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Items.Translations;

public class ItemTranslations : Profile
{
    public ItemTranslations()
    {
        CreateMap<Item, ItemDto>();
        CreateMap<ItemDto, Item>();
    }
}