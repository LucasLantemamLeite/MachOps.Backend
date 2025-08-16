using MachOps.Application.Shared.ResultCases;
using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.Handlers;

public interface IGetAllMachineryHandler
{
    public Task<Result<List<Machinery>>> Handle();
}
