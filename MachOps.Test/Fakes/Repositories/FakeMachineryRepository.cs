using MachOps.Application.Interfaces.Repositories;
using MachOps.Domain.Entities;

namespace MachOps.Test.Fakes.Repositories;

public sealed class FakeMachineryRepository : IMachineryRepository
{
    private readonly List<Machinery> _machines;

    public FakeMachineryRepository(List<Machinery> machines) => _machines = machines;

    public Task<int> CreateAsync(Machinery machine)
    {
        var existingMachine = _machines.FirstOrDefault(x => x.Name.Value == machine.Name.Value);

        if (existingMachine is not null)
            return Task.FromResult(0);

        _machines.Add(machine);

        return Task.FromResult(1);
    }

    public Task<int> DeleteAsync(Machinery machine)
    {
        var existingMachine = _machines.FirstOrDefault(x => x.Id == machine.Id);

        if (existingMachine is null)
            return Task.FromResult(0);

        _machines.Remove(existingMachine);

        return Task.FromResult(1);
    }

    public Task<int> UpdateAsync(Machinery machine)
    {
        var index = _machines.FindIndex(x => x.Id == machine.Id);

        if (index is -1)
            return Task.FromResult(0);

        _machines[index] = machine;

        return Task.FromResult(1);
    }
}
