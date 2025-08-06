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

    protected BaseUseCase(TQuery query)
    {
        _query = query;
    }

    protected BaseUseCase(TRepository repository)
    {
        _repository = repository;
    }

    protected TQuery Query => _query ?? throw new InvalidOperationException("Query não foi injetado.");

    protected TRepository Repository => _repository ?? throw new InvalidOperationException("Repository não foi injetado.");
}
