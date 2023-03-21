using AutoMapper;
using CatalogService.Application.Items.Dto;
using MediatR;

namespace CatalogService.Application.Items.Queries;

public record ListItemsQuery() : IRequest<IEnumerable<ItemDto>>;

public class ListItemsQueryHandler : IRequestHandler<ListItemsQuery, IEnumerable<ItemDto>>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public ListItemsQueryHandler(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ItemDto>> Handle(ListItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.ListAsync();
        return _mapper.Map<List<ItemDto>>(items);
    }
}