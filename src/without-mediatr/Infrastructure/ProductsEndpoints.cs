using Demo.DTOs;
using Demo.UseCases;

namespace Demo.Infrastructure;

public static class ProductsEndpoints
{
    public static void MapProductsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/products", (GetProductsUseCase useCase) =>
        {
            var products = useCase.Handle();

            return Results.Ok(products);
        });



        endpoints.MapGet("/products/{id}", async (GetProductUseCase useCase, Guid id) =>
        {
            var product = useCase.Handle(id);

            if(product is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product);
        }).WithName("GetProduct");



        endpoints.MapPost("/products", (AddProductUseCase useCase, Request request) =>
        {
            var id = useCase.Handle(
                request.Name,
                request.Quantity,
                request.Price);

            return Results.CreatedAtRoute(
                "GetProduct",
                new { id },
                id);
        });



        endpoints.MapPut("/products/{id}", (UpdateProductUseCase useCase, Guid id, Request request) =>
        {
            var result = useCase.Handle(
                id,
                request.Name,
                request.Quantity,
                request.Price);

            if(!result)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });



        endpoints.MapDelete("/products/{id}", (DeleteProductUseCase useCase, Guid id) =>
        {
            var result = useCase.Handle(id);
            if(!result)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        });
    }
}
