using CatalogService.Application.Categories.Dto;
using MediatR;

namespace CatalogService.Application.Categories.Queries;

public record ListCategoriesQuery() : IRequest<IEnumerable<CategoryDto>>;

public class ListCategoriesQueryHandler : IRequestHandler<ListCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;

    public ListCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryDto>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.ListAsync();
        return categories.Map();
    }
}