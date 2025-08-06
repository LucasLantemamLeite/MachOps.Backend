using MachOps.Application.Shared.Commands;
using MachOps.Application.Shared.ResultCases;
using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.UseCases;

public interface ICreateMachineUseCase
{
    Task<Result<MachineEntity>> ExecuteAsync(CreateMachineCommand command);
}