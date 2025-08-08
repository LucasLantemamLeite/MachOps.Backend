using MachOps.Application.Interfaces.Handlers;
using MachOps.Application.Interfaces.UseCases;
using MachOps.Application.Shared.Commands;
using MachOps.Application.Shared.DTOs;
using MachOps.Application.Shared.ResultCases;
using MachOps.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MachOps.Api.Orchestrations.Handlers;

public sealed class CreateMachineHandler : ICreateMachineHandler
{
    private readonly ICreateMachineUseCase _useCase;

    public CreateMachineHandler(ICreateMachineUseCase useCase) => _useCase = useCase;

    public async Task<Result<MachineEntity>> Handle(CreateMachineDto machinedto)
    {
        var command = new CreateMachineCommand
        (
            machinedto.Name,
            machinedto.MachType,
            machinedto.Status,
            machinedto.Location,
            machinedto.Description,
            machinedto.MaintenceStartDate,
            machinedto.ExpectedReturnDate
        );

        var result = await _useCase.ExecuteAsync(command);

        return result;
    }
}