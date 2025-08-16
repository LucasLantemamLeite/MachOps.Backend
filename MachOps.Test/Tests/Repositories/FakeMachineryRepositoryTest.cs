using MachOps.Domain.Entities;
using MachOps.Test.Fakes.Base;
using MachOps.Test.Fakes.Repositories;

namespace MachOps.Test.Repositories;

[Trait("Category", "FakeMachineryRepositoryTest")]
public sealed class FakeMachineryRepositoryTest : FakeBaseDb
{
    private readonly FakeMachineryRepository _repository;

    public FakeMachineryRepositoryTest() => _repository = new FakeMachineryRepository(machines);

    [Fact]
    public async Task Create_WithValidMachinery_ShouldReturnRowsEffects()
    {
        var machine = new Machinery(id: 3,
            name: "BC-12",
            machType: 5,
            status: 1,
            location: "Bloco D",
            createdAt: new DateTime(2022, 10, 6),
            updatedAt: new DateTime(2023, 1, 24),
            description: null,
            maintenanceStart: new DateTime(2023, 06, 21),
            expectedReturn: new DateTime(2024, 2, 6));

        var row = await _repository.CreateAsync(machine);

        Assert.Equal(1, row);
        Assert.Contains(machines, x => x.Name.Value == machine.Name.Value);
    }

    [Fact]
    public async Task Delete_WithValidMachineryExisting_ShouldReturnRowsEffects()
    {
        var machine = new Machinery
        (
            id: 1,
            name: "Empilhadeira",
            machType: 1,
            status: 3,
            location: "Galpão A",
            createdAt: new DateTime(2025, 1, 15),
            updatedAt: new DateTime(2025, 6, 10),
            description: null,
            maintenanceStart: new DateTime(2025, 8, 1),
            expectedReturn: new DateTime(2025, 8, 5)
        );

        var row = await _repository.DeleteAsync(machine);

        Assert.Equal(1, row);
        Assert.DoesNotContain(machines, x => x.Id == machine.Id);
    }

    [Fact]
    public async Task Update_WithValidMachineryExisting_ShouldReturnRowsEffects()
    {
        var machine = new Machinery
        (
            id: 1,
            name: "Escavadeira",
            machType: 2,
            status: 1,
            location: "Doca 1",
            createdAt: new DateTime(2025, 1, 15),
            updatedAt: new DateTime(2025, 6, 10),
            description: "Carregando Caixotes",
            maintenanceStart: null,
            expectedReturn: null
        );

        var row = await _repository.UpdateAsync(machine);

        Assert.Equal(1, row);
        Assert.Contains(machines, x => x.Name.Value == machine.Name.Value);
    }
}