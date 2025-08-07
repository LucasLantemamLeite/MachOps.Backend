using MachOps.Application.Interfaces.Repositories;
using MachOps.Domain.Entities;

namespace MachOps.Test.Fakes.Repositories;

public sealed class FakeMachineRepository : IMachineRepository
{
    private readonly List<MachineEntity> _machines;

    public FakeMachineRepository(List<MachineEntity> machines) => _machines = machines;

    public Task<int> CreateAsync(MachineEntity machine)
    {
        var existingMachine = _machines.FirstOrDefault(x => x.Name.Value == machine.Name.Value);

        if (existingMachine is null)
            return Task.FromResult(0);

        _machines.Add(machine);

        return Task.FromResult(1);
    }

    public Task<int> DeleteAsync(MachineEntity machine)
    {
        var existingMachine = _machines.FirstOrDefault(x => x.Id == machine.Id);

        if (existingMachine is null)
            return Task.FromResult(0);

        _machines.Remove(existingMachine);

        return Task.FromResult(1);
    }

    public Task<int> UpdateAsync(MachineEntity machine)
    {
        var index = _machines.FindIndex(x => x.Id == machine.Id);

        if (index is -1)
            return Task.FromResult(0);

        _machines[index] = machine;

        return Task.FromResult(1);
    }
}
