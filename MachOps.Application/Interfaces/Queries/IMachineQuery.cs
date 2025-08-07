using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.Queries;

public interface IMachineQuery
{
    Task<List<MachineEntity>> GetAllAsync();
    Task<MachineEntity?> GetByIdAsync(int id);
    Task<MachineEntity?> GetByNameAsync(string name);
    Task<List<MachineEntity>> GetByMachTypeAsync(int type);
    Task<List<MachineEntity>> GetByStatusAsync(int status);
    Task<List<MachineEntity>> GetByIntervalAsync(DateTime maintenanceStart, DateTime expectReturn);
    Task<List<MachineEntity>> GetByMaintenceStartDateAsync(DateTime maintenanceStart);
    Task<List<MachineEntity>> GetByExpectedReturnDateAsync(DateTime expectReturn);
}