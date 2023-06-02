using MediatR;

namespace CatalogService.Application.Categories.Commands;

public record UpdateCategoryCommand(int Id, string Name, Uri Image) : IRequest<bool>
{
    public int ParentCategoryId { get; init; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = request.Map();
        return await _categoryRepository.UpdateAsync(category);
    }
}