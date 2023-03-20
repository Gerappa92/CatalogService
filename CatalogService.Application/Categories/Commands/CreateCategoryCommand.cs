using AutoMapper;
using CatalogService.Domain.Entities;
using MediatR;

namespace CatalogService.Application.Categories.Commands;


public record CreateCategoryCommand(string Name, Uri Image) : IRequest<int>
{
    public int ParentCategoryId { get; init; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        return await _categoryRepository.AddAsync(category);
    }
}

