using MachOps.Application.Interfaces.Queries;
using MachOps.Application.Interfaces.Repositories;
using MachOps.Application.Interfaces.UseCases;
using MachOps.Application.Shared.Commands;
using MachOps.Application.Shared.ResultCases;
using MachOps.Application.Shared.UseCases.Base;
using MachOps.Domain.Entities;
using MachOps.Domain.ValueObjects.Validations;

namespace MachOps.Application.Shared.UseCases;

public sealed class CreateMachineUseCase : BaseUseCase<IMachineQuery, IMachineRepository>, ICreateMachineUseCase
{
    public CreateMachineUseCase(IMachineQuery query, IMachineRepository repository) : base(query, repository) { }

    public async Task<Result<MachineEntity>> ExecuteAsync(CreateMachineCommand command)
    {
        try
        {
            var existingMachine = await Query.GetByNameAsync(command.Name);

            if (existingMachine is not null)
                return Result<MachineEntity>.Fail("Name já está em uso.");

            var machine = new MachineEntity
            (
                command.Name,
                command.MachType,
                command.Location,
                command.Status,
                command.Description,
                command.MaintenceStartDate,
                command.ExpectedReturnDate
            );

            var row = await Repository.CreateAsync(machine);

            if (row == 0)
                return Result<MachineEntity>.Fail("Erro interno no servidor. Falha ao criar nova Machine");

            return Result<MachineEntity>.Ok("Machine criado com sucesso.", machine);
        }

        catch (Exception ex) when (ex is DomainException or EnumException)
        {
            return Result<MachineEntity>.Fail($"{ex.Message}");
        }

        catch
        {
            return Result<MachineEntity>.Fail("Erro interno do servidor. Tente novamento mais tarde.");
        }
    }
}