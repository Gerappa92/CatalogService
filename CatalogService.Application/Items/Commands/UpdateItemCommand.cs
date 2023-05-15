using CatalogService.Application.Items.Messages;
using MediatR;

namespace CatalogService.Application.Items.Commands;

public class UpdateItemCommand : IRequest<bool>
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public Uri Image { get; init; }
    public decimal Price { get; init; }
    public int CategoryId { get; init; }
}

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, bool>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMessageBroker<ItemUpdateMessage> _messageBroker;

    public UpdateItemCommandHandler(IItemRepository itemRepository, IMessageBroker<ItemUpdateMessage> messageBroker)
    {
        _itemRepository = itemRepository;
        _messageBroker = messageBroker;
    }

    public async Task<bool> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = request.Map();
        var updated = await _itemRepository.UpdateAsync(item);
        if (updated)
        {
            var msg = item.MapToMessage();
            _messageBroker.Send(msg);
        }
        return updated;
    }
}