using AutoMapper;
using CatalogService.Application.Items.Dto;
using MediatR;

namespace CatalogService.Application.Items.Queries;

public record GetItemQuery(int Id) : IRequest<ItemDto>;

public class GetItemQueryHandler : IRequestHandler<GetItemQuery, ItemDto>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetItemQueryHandler(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<ItemDto> Handle(GetItemQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ItemDto>(item);
    }
}
