using AutoMapper;
using CatalogService.Application.Categories.Dtos;
using MediatR;

namespace CatalogService.Application.Categories.Queries;

public record ListCategoriesQuery() : IRequest<IEnumerable<CategoryDto>>;

public class ListCategoriesQueryHandler : IRequestHandler<ListCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public ListCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.ListAsync();
        return _mapper.Map<List<CategoryDto>>(categories);
    }
}