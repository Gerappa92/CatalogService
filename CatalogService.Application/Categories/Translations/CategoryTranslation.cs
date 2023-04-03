using AutoMapper;
using CatalogService.Application.Categories.Dto;
using CatalogService.Domain.Entities;

namespace CatalogService.Application.Categories.Translations;

public class CategoryTranslation : Profile
{
    public CategoryTranslation()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
    }
}