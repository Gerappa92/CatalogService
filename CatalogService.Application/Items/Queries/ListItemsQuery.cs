using CatalogService.Application.Items.Dto;
using MediatR;

namespace CatalogService.Application.Items.Queries;

public record ListItemsQuery() : IRequest<IEnumerable<ItemDto>>;

public class ListItemsQueryHandler : IRequestHandler<ListItemsQuery, IEnumerable<ItemDto>>
{
    private readonly IItemRepository _itemRepository;

    public ListItemsQueryHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<ItemDto>> Handle(ListItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.ListAsync();
        return items.Map();
    }
}