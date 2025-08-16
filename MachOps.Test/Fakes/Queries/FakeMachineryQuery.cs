using MachOps.Application.Interfaces.Queries;
using MachOps.Domain.Entities;

namespace MachOps.Test.Fakes.Queries;

public sealed class FakeMachineryQuery : IMachineryQuery
{
    private readonly List<Machinery> _machines;

    public FakeMachineryQuery(List<Machinery> machines) => _machines = machines;

    public Task<List<Machinery>> GetAllAsync()
    {
        return Task.FromResult(_machines);
    }

    public Task<List<Machinery>> GetByExpectedReturnDateAsync(DateTime expectReturn)
    {
        var machines = _machines.Where(x => x.MaintenanceReturn.Value == expectReturn).ToList();

        return Task.FromResult(machines);
    }

    public Task<Machinery?> GetByIdAsync(int id)
    {
        var machine = _machines.FirstOrDefault(x => x.Id == id);

        return Task.FromResult(machine);
    }

    public Task<List<Machinery>> GetByIntervalAsync(DateTime maintenanceStart, DateTime expectReturn)
    {
        var machines = _machines.Where(x => x.MaintenanceStart.Value >= maintenanceStart && x.MaintenanceReturn.Value < expectReturn).ToList();

        return Task.FromResult(machines);
    }

    public Task<List<Machinery>> GetByTypeAsync(int type)
    {
        var machines = _machines.Where(x => (int)x.MachType.Value == type).ToList();

        return Task.FromResult(machines);
    }

    public Task<List<Machinery>> GetByMaintenceStartDateAsync(DateTime maintenanceStart)
    {
        var machines = _machines.Where(x => x.MaintenanceStart.Value == maintenanceStart).ToList();

        return Task.FromResult(machines);
    }

    public Task<Machinery?> GetByNameAsync(string name)
    {
        var machine = _machines.FirstOrDefault(x => x.Name.Value == name);

        return Task.FromResult(machine);
    }

    public Task<List<Machinery>> GetByStatusAsync(int status)
    {
        var machines = _machines.Where(x => (int)x.Status.Value == status).ToList();

        return Task.FromResult(machines);
    }
}