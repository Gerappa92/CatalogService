using CatalogService.Application.Categories.Commands;
using CatalogService.Application.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Web.Endpoints.Category;

public class CategoryEndpoints
{
    /// <summary>
    /// List all categories
    /// </summary>
    public async Task<IResult> ListCategories([FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new ListCategoriesQuery());
        return Results.Ok(result);
    }

    /// <summary>
    /// Add a new category
    /// </summary>
    public async Task<IResult> AddCategory([FromBody] CreateCategoryCommand command,
        [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(command);
        return Results.Ok(result);
    }

    /// <summary>
    /// Update a category
    /// </summary>
    public async Task<IResult> UpdateCategory([FromBody] UpdateCategoryCommand command,
        [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(command);
        return Results.Ok(result);
    }

    /// <summary>
    /// Delete a category
    /// </summary>
    public async Task<IResult> DeleteCategory([FromRoute] int id,
        [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(new DeleteCategoryCommand(id));
        return Results.Ok(result);
    }
}