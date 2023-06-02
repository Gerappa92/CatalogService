using MediatR;

namespace CatalogService.Application.Categories.Commands;

public record CreateCategoryCommand(string Name, Uri Image, int? ParentId) : IRequest<int>;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = request.Map();
        return await _categoryRepository.AddAsync(category);
    }
}