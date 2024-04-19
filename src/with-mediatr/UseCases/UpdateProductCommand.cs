using Demo.Infrastructure;
using MediatR;

namespace Demo.UseCases;

public sealed record UpdateProductCommand(Guid Id, string Name, uint Quantity, double Price) : IRequest<bool>
{
    internal sealed class Handler(IProductsRepository repository) : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductsRepository _repository = repository;

        public Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _repository.Get(request.Id);
            if(product is null)
            {
                return Task.FromResult(false);
            }

            product.Name = request.Name;
            product.Quantity = request.Quantity;
            product.Price = request.Price;

            _repository.Update(product);

            return Task.FromResult(true);
        }
    }
}
