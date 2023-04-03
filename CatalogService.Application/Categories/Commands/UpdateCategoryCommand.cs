using AutoMapper;
using CatalogService.Domain.Entities;
using MediatR;

namespace CatalogService.Application.Categories.Commands;

public record UpdateCategoryCommand(string Name, Uri Image) : IRequest<bool>
{
    public int ParentCategoryId { get; init; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);
        return await _categoryRepository.UpdateAsync(category);
    }
}