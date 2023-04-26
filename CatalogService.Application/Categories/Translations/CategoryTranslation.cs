using CatalogService.Application.Categories.Commands;
using CatalogService.Application.Categories.Dto;
using CatalogService.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace CatalogService.Application.Categories.Translations;

[Mapper]
public static partial class CategoryTranslation
{
    public static partial Category Map(this CreateCategoryCommand dto);
    public static partial Category Map(this UpdateCategoryCommand dto);
    public static partial CategoryDto Map(this Category entity);
    public static partial IEnumerable<CategoryDto> Map(this IEnumerable<Category> entities);

}