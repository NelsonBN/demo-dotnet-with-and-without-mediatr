using Demo.Infrastructure;
using MediatR;
using static Demo.UseCases.GetProductQuery;

namespace Demo.UseCases;

public sealed record GetProductQuery(Guid Id) : IRequest<Response?>
{
    internal sealed class Handler(IProductsRepository repository) : IRequestHandler<GetProductQuery, Response?>
    {
        private readonly IProductsRepository _repository = repository;

        public Task<Response?> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _repository.Get(request.Id);

            if(product is null)
            {
                return Task.FromResult<Response?>(null);
            }

            return Task.FromResult<Response?>(new(
                product.Id,
                product.Name,
                product.Quantity,
                product.Price));
        }
    }

    public sealed record Response(
        Guid Id,
        string Name,
        uint Quantity,
        double Price);
}
