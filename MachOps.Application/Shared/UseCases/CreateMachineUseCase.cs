using MachOps.Application.Interfaces.Queries;
using MachOps.Application.Interfaces.Repositories;
using MachOps.Application.Shared.Commands;
using MachOps.Application.Shared.Result;
using MachOps.Domain.Entities;
using MachOps.Domain.ValueObjects.Validations;

namespace MachOps.Application.Shared.UseCases;

public sealed class CreateMachineUseCase
{
    private readonly IMachineRepository _repository;
    private readonly IMachineQuery _query;

    public CreateMachineUseCase(IMachineRepository repository, IMachineQuery query)
    {
        _repository = repository;
        _query = query;
    }

    public async Task<Result<MachineEntity>> ExecuteAsync(CreateMachineCommand command)
    {
        try
        {

        }

        catch (Exception ex) when (ex is DomainException or EnumException)
        {

        }

        catch
        {

        }
    }
}