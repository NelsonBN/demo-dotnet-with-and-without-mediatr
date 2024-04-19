using Demo.Infrastructure;

namespace Demo.UseCases;

public sealed class GetProductsUseCase(IProductsRepository repository)
{
    private readonly IProductsRepository _repository = repository;

    public IEnumerable<Response> Handle()
    {
        var products = _repository
            .List()
            .Select(s => new Response(s.Id, s.Name));

        return products;
    }

    public sealed record Response(Guid Id, string Name);
}
