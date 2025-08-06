using MachOps.Application.Interfaces.Queries;
using MachOps.Domain.Entities;

namespace MachOps.Test.Fakes.Queries;

public sealed class FakeMachineQuery : IMachineQuery
{
    private readonly IEnumerable<MachineEntity> _machines;

    public FakeMachineQuery(IEnumerable<MachineEntity> machines) => _machines = machines;

    public Task<IEnumerable<MachineEntity>> GetAllAsync()
    {
        return Task.FromResult(_machines);
    }

    public Task<IEnumerable<MachineEntity>> GetByExpectedReturnDateAsync(DateTime expectReturn)
    {
        var machines = _machines.Where(x => x.ExpectedReturnDate.Value == expectReturn);

        return Task.FromResult(machines);
    }

    public Task<MachineEntity?> GetByIdAsync(int id)
    {
        var machine = _machines.FirstOrDefault(x => x.Id == id);

        return Task.FromResult(machine);
    }

    public Task<IEnumerable<MachineEntity>> GetByIntervalAsync(DateTime maintenanceStart, DateTime expectReturn)
    {
        var machines = _machines.Where(x => x.MaintenceStartDate.Value >= maintenanceStart && x.ExpectedReturnDate.Value < expectReturn);

        return Task.FromResult(machines);
    }

    public Task<IEnumerable<MachineEntity>> GetByMachTypeAsync(int type)
    {
        var machines = _machines.Where(x => (int)x.MachType.Value == type);

        return Task.FromResult(machines);
    }

    public Task<IEnumerable<MachineEntity>> GetByMaintenceStartDateAsync(DateTime maintenanceStart)
    {
        var machines = _machines.Where(x => x.MaintenceStartDate.Value == maintenanceStart);

        return Task.FromResult(machines);
    }

    public Task<MachineEntity?> GetByNameAsync(string name)
    {
        var machine = _machines.FirstOrDefault(x => x.Name.Value == name);

        return Task.FromResult(machine);
    }

    public Task<IEnumerable<MachineEntity>> GetByStatusAsync(int status)
    {
        var machines = _machines.Where(x => (int)x.Status.Value == status);

        return Task.FromResult(machines);
    }
}