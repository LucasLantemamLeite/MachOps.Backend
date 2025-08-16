using MachOps.Application.Shared.DTOs;
using MachOps.Application.Shared.ResultCases;
using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.Handlers;

public interface ICreateMachineryHandler
{
    public Task<Result<Machinery>> Handle(CreateMachineryDto machine_dto);
}