using MediatR;

namespace CatalogService.Application.Items.Commands;

public record DeleteItemCommand(int Id) : IRequest<bool>;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, bool>
{
    private readonly IItemRepository _itemRepository;

    public DeleteItemCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        return await _itemRepository.DeleteAsync(request.Id);
    }
}