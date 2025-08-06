using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.Repositories;

public interface IMachineRepository
{
    Task<int> CreateAsync(MachineEntity machine);
    Task<int> DeleteAsync(MachineEntity machine);
    Task<int> UpdateAsync(MachineEntity machine);
}