using MediatR;

namespace CatalogService.Application.Items.Commands;

public class CreateItemCommand : IRequest<int>
{
    public string Name { get; init; }
    public string Description { get; init; }
    public Uri Image { get; init; }
    public decimal Price { get; init; }
    public int CategoryId { get; init; }
}

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
{
    private readonly IItemRepository _itemRepository;

    public CreateItemCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var item = request.Map();
        return await _itemRepository.AddAsync(item);
    }
}