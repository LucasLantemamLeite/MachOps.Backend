using MachOps.Domain.Entities;

namespace MachOps.Application.Interfaces.Queries;

public interface IMachineryQuery
{
    Task<List<Machinery>> GetAllAsync();
    Task<Machinery?> GetByIdAsync(int id);
    Task<Machinery?> GetByNameAsync(string name);
    Task<List<Machinery>> GetByTypeAsync(int type);
    Task<List<Machinery>> GetByStatusAsync(int status);
    Task<List<Machinery>> GetByIntervalAsync(DateTime maintenanceStart, DateTime expectReturn);
    Task<List<Machinery>> GetByMaintenceStartDateAsync(DateTime maintenanceStart);
    Task<List<Machinery>> GetByExpectedReturnDateAsync(DateTime expectReturn);
}