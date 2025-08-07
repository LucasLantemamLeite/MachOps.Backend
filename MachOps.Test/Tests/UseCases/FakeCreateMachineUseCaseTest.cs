using MachOps.Application.Shared.Commands;
using MachOps.Test.Fakes.Base;
using MachOps.Test.Fakes.UseCases;

namespace MachOps.Test.UseCases;

[Trait("Category", "FakeUseCaseTest")]
public sealed class FakeCreateMachineUseCaseTest : FakeBaseDb
{
    private readonly FakeCreateMachineUseCase _useCase;

    public FakeCreateMachineUseCaseTest() => _useCase = new FakeCreateMachineUseCase(machines);

    [Fact]
    public async Task CreateMachineUseCase_WithValidCommand_ShouldReturnSuccess()
    {
        var command = new CreateMachineCommand(
            name: "Bc-009",
            machType: 5,
            status: 1,
            location: "Bloco D",
            description: null,
            maintenceStart: new DateTime(2023, 06, 21),
            expectedReturn: new DateTime(2024, 2, 6)
        );

        var result = await _useCase.ExecuteAsync(command);

        Assert.True(result.Success);
        Assert.NotNull(result.Data);
        Assert.Equal("Machine criado com sucesso.", result.Message);
        Assert.Contains(machines, x => x.Name.Value == command.Name);
    }

    [Fact]
    public async Task CreateMachineUseCase_WithExistingName_ShouldNotReturnSuccess()
    {
        var command = new CreateMachineCommand(
            name: "Guindaste",
            machType: 6,
            status: 3,
            location: "Doca 3",
            description: "Em manutenção crítica.",
            maintenceStart: new DateTime(2025, 7, 20),
            expectedReturn: new DateTime(2025, 8, 10)
        );

        var result = await _useCase.ExecuteAsync(command);

        Assert.False(result.Success);
        Assert.Null(result.Data);
        Assert.Equal("Name já está em uso.", result.Message);
        Assert.Contains(machines, x => x.Name.Value == command.Name);
    }

    [Fact]
    public async Task CreateMachineUseCase_WithEmptyName_ShouldNotReturnSuccess()
    {
        var command = new CreateMachineCommand(
            name: "",
            machType: 6,
            status: 3,
            location: "Doca 3",
            description: "Em manutenção crítica.",
            maintenceStart: new DateTime(2025, 7, 20),
            expectedReturn: new DateTime(2025, 8, 10)
        );

        var result = await _useCase.ExecuteAsync(command);

        Assert.False(result.Success);
        Assert.Null(result.Data);
        Assert.Equal("Name não pode ser nulo nem vazio.", result.Message);
        Assert.DoesNotContain(machines, x => x.Name.Value == command.Name);
    }

    [Fact]
    public async Task CreateMachineUseCase_WitMachTypeInvalid_ShouldNotReturnSuccess()
    {
        var command = new CreateMachineCommand(
            name: "Bc-009",
            machType: 7,
            status: 3,
            location: "Doca 3",
            description: "Em manutenção crítica.",
            maintenceStart: new DateTime(2025, 7, 20),
            expectedReturn: new DateTime(2025, 8, 10)
        );

        var result = await _useCase.ExecuteAsync(command);

        Assert.False(result.Success);
        Assert.Null(result.Data);
        Assert.Equal("MachType inválido.", result.Message);
        Assert.DoesNotContain(machines, x => x.Name.Value == command.Name);
    }

    [Fact]
    public async Task CreateMachineUseCase_WitStatusInvalid_ShouldNotReturnSuccess()
    {
        var command = new CreateMachineCommand(
            name: "Bc-009",
            machType: 6,
            status: 4,
            location: "Doca 3",
            description: "Em manutenção crítica.",
            maintenceStart: new DateTime(2025, 7, 20),
            expectedReturn: new DateTime(2025, 8, 10)
        );

        var result = await _useCase.ExecuteAsync(command);

        Assert.False(result.Success);
        Assert.Null(result.Data);
        Assert.Equal("Status inválido.", result.Message);
        Assert.DoesNotContain(machines, x => x.Name.Value == command.Name);
    }
}