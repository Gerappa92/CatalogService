using CatalogService.Application.Items.Dto;
using MediatR;

namespace CatalogService.Application.Items.Queries;

public record GetItemQuery(int Id) : IRequest<ItemDto>;

public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemDto>
{
    private readonly IItemRepository _itemRepository;

    public GetItemQueryHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<ItemDto> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(request.Id);
        return item.Map();
    }
}
