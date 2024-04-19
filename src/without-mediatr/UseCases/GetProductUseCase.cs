using Demo.Infrastructure;

namespace Demo.UseCases;

public sealed class GetProductUseCase(IProductsRepository repository)
{
    private readonly IProductsRepository _repository = repository;

    public Response? Handle(Guid id)
    {
        var product = _repository.Get(id);

        if(product is null)
        {
            return null;
        }

        return new(
            product.Id,
            product.Name,
            product.Quantity,
            product.Price);
    }

    public sealed record Response(
        Guid Id,
        string Name,
        uint Quantity,
        double Price);
}
