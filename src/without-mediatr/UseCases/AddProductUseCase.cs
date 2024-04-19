using Demo.Entities;
using Demo.Infrastructure;

namespace Demo.UseCases;

public sealed class AddProductUseCase(IProductsRepository repository)
{
    private readonly IProductsRepository _repository = repository;

    public Guid Handle(string name, uint quantity, double price)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Quantity = quantity,
            Price = price
        };

        _repository.Add(product);

        return product.Id;
    }
}
