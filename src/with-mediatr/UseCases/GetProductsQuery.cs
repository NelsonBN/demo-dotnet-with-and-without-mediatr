using Demo.Infrastructure;
using MediatR;
using static Demo.UseCases.GetProductsQuery;

namespace Demo.UseCases;

public sealed record GetProductsQuery : IRequest<IEnumerable<Response>>
{
    public static GetProductsQuery Instance => new();

    internal sealed class Handler(IProductsRepository repository) : IRequestHandler<GetProductsQuery, IEnumerable<Response>>
    {
        private readonly IProductsRepository _repository = repository;

        public Task<IEnumerable<Response>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = _repository
                .List()
                .Select(s => new Response(s.Id, s.Name));

            return Task.FromResult(products);
        }
    }

    public sealed record Response(Guid Id, string Name);
}
