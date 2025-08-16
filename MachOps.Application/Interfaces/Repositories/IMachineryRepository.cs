using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.Repositories;

public interface IMachineryRepository
{
    Task<int> CreateAsync(Machinery machine);
    Task<int> DeleteAsync(Machinery machine);
    Task<int> UpdateAsync(Machinery machine);
}