using Demo.Infrastructure;
using MediatR;

namespace Demo.UseCases;

public sealed record DeleteProductCommand(Guid Id) : IRequest<bool>
{
    internal sealed class Handler(IProductsRepository repository) : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductsRepository _repository = repository;

        public Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            if(!_repository.Exists(request.Id))
            {
                return Task.FromResult(false);
            }

            _repository.Delete(request.Id);

            return Task.FromResult(true);
        }
    }
}
