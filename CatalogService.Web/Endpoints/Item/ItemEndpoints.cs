using CatalogService.Application.Items.Commands;
using CatalogService.Application.Items.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Web.Endpoints.Item;

public class ItemEndpoints
{
    public async Task<IResult> ListItems([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new ListItemsQuery());
        return Results.Ok(result);
    }

    public async Task<IResult> AddItem([FromBody] CreateItemCommand command, [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(command);
        return Results.Ok(result);
    }

    public async Task<IResult> UpdateItem([FromBody] UpdateItemCommand command, [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(command);
        return Results.Ok(result);
    }

    public async Task<IResult> DeleteItem([FromRoute] int id, [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new DeleteItemCommand(id));
        return Results.Ok(result);
    }
}