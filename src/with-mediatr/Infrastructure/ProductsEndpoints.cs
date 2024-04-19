using Demo.DTOs;
using Demo.UseCases;
using MediatR;

namespace Demo.Infrastructure;

public static class ProductsEndpoints
{
    public static void MapProductsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/products", async (IMediator mediator) =>
        {
            var products = await mediator.Send(GetProductsQuery.Instance);

            return Results.Ok(products);
        });



        endpoints.MapGet("/products/{id}", async (IMediator mediator, Guid id) =>
        {
            var product = await mediator.Send(new GetProductQuery(id));

            if(product is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product);
        }).WithName("GetProduct");



        endpoints.MapPost("/products", async (IMediator mediator, Request request) =>
        {
            var id = await mediator.Send(new AddProductCommand(
                request.Name,
                request.Quantity,
                request.Price));

            return Results.CreatedAtRoute(
                "GetProduct",
                new { id },
                id);
        });



        endpoints.MapPut("/products/{id}", async (IMediator mediator, Guid id, Request request) =>
        {
            var result = await mediator.Send(new UpdateProductCommand(
                id,
                request.Name,
                request.Quantity,
                request.Price));

            if(!result)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });



        endpoints.MapDelete("/products/{id}", async (IMediator mediator, Guid id) =>
        {
            var result = await mediator.Send(new DeleteProductCommand(id));
            if(!result)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });
    }
}
