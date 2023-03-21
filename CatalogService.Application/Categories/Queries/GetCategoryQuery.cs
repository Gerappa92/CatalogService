using AutoMapper;
using CatalogService.Application.Categories.Dto;
using MediatR;

namespace CatalogService.Application.Categories.Queries;

public record GetCategoryQuery(int Id) : IRequest<CategoryDto>;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        return _mapper.Map<CategoryDto>(category);
    }
}