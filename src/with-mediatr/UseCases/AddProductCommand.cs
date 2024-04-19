using Demo.Entities;
using Demo.Infrastructure;
using MediatR;

namespace Demo.UseCases;

public sealed record AddProductCommand(string Name, uint Quantity, double Price) : IRequest<Guid>
{
    internal sealed class Handler(IProductsRepository repository) : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IProductsRepository _repository = repository;

        public Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Quantity = request.Quantity,
                Price = request.Price
            };

            _repository.Add(product);

            return Task.FromResult(product.Id);
        }
    }
}
