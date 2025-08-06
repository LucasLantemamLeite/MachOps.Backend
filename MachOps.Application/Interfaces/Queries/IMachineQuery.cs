using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.Queries;

public interface IMachineQuery
{
    Task<IEnumerable<MachineEntity>> GetAllAsync();
    Task<MachineEntity?> GetByIdAsync(int id);
    Task<IEnumerable<MachineEntity>> GetByNameAsync(string name);
    Task<IEnumerable<MachineEntity>> GetByMachTypeAsync(int type);
    Task<IEnumerable<MachineEntity>> GetByStatusAsync(int status);
    Task<IEnumerable<MachineEntity>> GetByIntervalAsync(DateTime maintenanceStart, DateTime expectReturn);
}