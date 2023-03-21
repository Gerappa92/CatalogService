﻿using AutoMapper;
using CatalogService.Domain.Entities;
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
    private readonly IMapper _mapper;

    public UpdateItemCommandHandler(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Item>(request);
        return await _itemRepository.UpdateAsync(item);
    }
}