using Demo.Infrastructure;

namespace Demo.UseCases;

public sealed class UpdateProductUseCase(IProductsRepository repository)
{
    private readonly IProductsRepository _repository = repository;

    public bool Handle(Guid id, string name, uint quantity, double price)
    {
        var product = _repository.Get(id);
        if(product is null)
        {
            return false;
        }

        product.Name = name;
        product.Quantity = quantity;
        product.Price = price;

        _repository.Update(product);

        return true;
    }
}
