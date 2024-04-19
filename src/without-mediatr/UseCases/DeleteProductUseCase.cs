using Demo.Infrastructure;

namespace Demo.UseCases;

public sealed class DeleteProductUseCase(IProductsRepository repository)
{
    private readonly IProductsRepository _repository = repository;

    public bool Handle(Guid id)
    {
        if(!_repository.Exists(id))
        {
            return false;
        }

        _repository.Delete(id);

        return true;
    }
}
