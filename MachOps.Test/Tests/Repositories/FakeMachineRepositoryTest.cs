using System.Threading.Tasks;
using MachOps.Domain.Entities;
using MachOps.Test.Fakes.Base;
using MachOps.Test.Fakes.Repositories;

namespace MachOps.Test.Repositories;

[Trait("Category", "FakeMachineRepositoryTest")]
public sealed class FakeMachineRepositoryTest : FakeBaseDb
{
    private readonly FakeMachineRepository _repository;

    public FakeMachineRepositoryTest() => _repository = new FakeMachineRepository(machines);

    [Fact]
    public async Task Create_WithValidMachineEntity_ShouldReturnRowsEffects()
    {
        var machine = new MachineEntity(id: 3,
            name: "Guindaste",
            machType: 5,
            status: 1,
            location: "Bloco D",
            create: new DateTime(2022, 10, 6),
            update: new DateTime(2023, 1, 24),
            description: null,
            maintenceStart: new DateTime(2023, 06, 21),
            expectedReturn: new DateTime(2024, 2, 6));

        var row = await _repository.CreateAsync(machine);

        Assert.Equal(1, row);
        Assert.Contains(machines, x => x.Name.Value == machine.Name.Value);
    }

    [Fact]
    public async Task Delete_WithValidMachineEntityExisting_ShouldReturnRowsEffects()
    {
        var machine = new MachineEntity
        (
            id: 1,
            name: "Empilhadeira",
            machType: 1,
            status: 3,
            location: "Galpão A",
            create: new DateTime(2025, 1, 15),
            update: new DateTime(2025, 6, 10),
            description: null,
            maintenceStart: new DateTime(2025, 8, 1),
            expectedReturn: new DateTime(2025, 8, 5)
        );

        var row = await _repository.DeleteAsync(machine);

        Assert.Equal(1, row);
        Assert.DoesNotContain(machines, x => x.Id == machine.Id);
    }

    [Fact]
    public async Task Update_WithValidMachineEntityExisting_ShouldReturnRowsEffects()
    {
        var machine = new MachineEntity
        (
            id: 1,
            name: "Escavadeira",
            machType: 2,
            status: 1,
            location: "Doca 1",
            create: new DateTime(2025, 1, 15),
            update: new DateTime(2025, 6, 10),
            description: "Carregando Caixotes",
            maintenceStart: null,
            expectedReturn: null
        );

        var row = await _repository.UpdateAsync(machine);

        Assert.Equal(1, row);
        Assert.Contains(machines, x => x.Name.Value == machine.Name.Value);
    }
}