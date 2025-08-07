namespace MachOps.Application.Shared.UseCases.Base;

public abstract class BaseUseCase<TQuery, TRepository>
    where TQuery : class
    where TRepository : class
{
    private readonly TQuery? _query = null;
    private readonly TRepository? _repository = null;

    protected BaseUseCase(TQuery query, TRepository repository)
    {
        _query = query;
        _repository = repository;
    }

    protected BaseUseCase(TQuery query) => _query = query;

    protected BaseUseCase(TRepository repository) => _repository = repository;

    protected BaseUseCase() { }

    protected TQuery Query => _query is Unused ? throw new InvalidOperationException($"Query do tipo {typeof(TQuery).Name} foi marcada como não usada.")
    : _query ?? throw new InvalidOperationException($"Query do tipo {typeof(TQuery).Name} não foi injetado.");

    protected TRepository Repository => _repository is Unused ? throw new InvalidOperationException($"Query do tipo {typeof(TRepository).Name} foi marcada como não usada.")
    : _repository ?? throw new InvalidOperationException($"Query do tipo {typeof(TRepository).Name} não foi injetado.");
}