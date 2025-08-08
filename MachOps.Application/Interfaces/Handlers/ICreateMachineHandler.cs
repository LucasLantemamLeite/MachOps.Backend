using MachOps.Application.Shared.DTOs;
using MachOps.Application.Shared.ResultCases;
using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.Handlers;

public interface ICreateMachineHandler
{
    public Task<Result<MachineEntity>> Handle(CreateMachineDto machine_dto);
}