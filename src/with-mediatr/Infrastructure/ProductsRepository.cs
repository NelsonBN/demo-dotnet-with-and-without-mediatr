using Demo.Entities;

namespace Demo.Infrastructure;

public interface IProductsRepository
{
    IEnumerable<Product> List();
    Product? Get(Guid id);
    void Add(Product product);
    void Update(Product product);
    void Delete(Guid id);
    bool Exists(Guid id);
}

internal sealed class ProductsRepository : IProductsRepository
{
    private static readonly Dictionary<Guid, Product> _storage;

    static ProductsRepository()
        => _storage = [];

    public IEnumerable<Product> List()
        => _storage.Values;

    public Product? Get(Guid id)
    {
        if(!_storage.TryGetValue(id, out var product))
        {
            return null;
        }

        return product;
    }

    public void Add(Product product)
        => _storage.Add(product.Id, product);

    public void Update(Product product)
        => _storage[product.Id] = product;

    public void Delete(Guid id)
        => _storage.Remove(id);

    public bool Exists(Guid id)
        => _storage.ContainsKey(id);
}
