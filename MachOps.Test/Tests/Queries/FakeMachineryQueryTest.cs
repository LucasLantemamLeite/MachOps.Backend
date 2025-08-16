using MachOps.Test.Fakes.Base;
using MachOps.Test.Fakes.Queries;

namespace MachOps.Test.Queries;

[Trait("Category", "FakeMachineryQueryTest")]
public sealed class FakeMachineryQueryTest : FakeBaseDb
{
    private readonly FakeMachineryQuery _query;

    public FakeMachineryQueryTest() => _query = new FakeMachineryQuery(machines);

    [Fact]
    public async Task All_WithAll_ShouldReturnIEnumerableOfMachineEntity()
    {
        var result = await _query.GetAllAsync();

        Assert.NotNull(result);
        Assert.Equal(4, result.Count());
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public async Task Id_WithExistingId_ShouldReturnMachineEntity(int id)
    {
        var result = await _query.GetByIdAsync(id);

        Assert.NotNull(result);
        Assert.Contains(machines, x => x.Id == id);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    public async Task Id_WithNonExistentId_ShouldReturnNull(int id)
    {
        var result = await _query.GetByIdAsync(id);

        Assert.Null(result);
        Assert.DoesNotContain(machines, x => x.Id == id);
    }

    [Theory]
    [InlineData(2025, 8, 1)]
    [InlineData(2025, 7, 20)]
    [InlineData(2025, 7, 15)]
    public async Task MaintenceStartDate_WithExistingDate_ShouldReturnIEnumerableOfMachineEntity(int year, int mouth, int day)
    {
        var date = new DateTime(year, mouth, day);

        var result = await _query.GetByMaintenceStartDateAsync(date);

        Assert.NotNull(result);
        Assert.Contains(machines, x => x.MaintenanceStart.Value == date);
    }

    [Theory]
    [InlineData(2025, 7, 6)]
    [InlineData(2023, 6, 15)]
    [InlineData(2024, 12, 2)]
    public async Task MaintenceStartDate_WithNonExistingDate_ShouldReturnEmptyIEnumerable(int year, int mouth, int day)
    {
        var date = new DateTime(year, mouth, day);

        var result = await _query.GetByMaintenceStartDateAsync(date);

        Assert.Empty(result);
        Assert.DoesNotContain(machines, x => x.MaintenanceStart.Value == date);
    }


    [Theory]
    [InlineData(2025, 7, 18)]
    [InlineData(2025, 8, 10)]
    [InlineData(2025, 8, 5)]
    public async Task ExpectedReturnDate_WithExistingDate_ShouldReturnIEnumerableOfMachineEntity(int year, int mouth, int day)
    {
        var date = new DateTime(year, mouth, day);

        var result = await _query.GetByExpectedReturnDateAsync(date);

        Assert.NotNull(result);
        Assert.Contains(machines, x => x.MaintenanceReturn.Value == date);
    }

    [Theory]
    [InlineData(2023, 2, 21)]
    [InlineData(2026, 6, 14)]
    [InlineData(2024, 12, 9)]
    public async Task ExpectedReturnDate_WithNonExistingDate_ShouldReturnEmptyIEnumerable(int year, int mouth, int day)
    {
        var date = new DateTime(year, mouth, day);

        var result = await _query.GetByExpectedReturnDateAsync(date);

        Assert.Empty(result);
        Assert.DoesNotContain(machines, x => x.MaintenanceReturn.Value == date);
    }

    [Fact]
    public async Task Interval_WithExistingDates_ShouldReturnIEnumerableOfMachineEntity()
    {
        var start = new DateTime(2025, 8, 1);
        var end = new DateTime(2025, 8, 5).AddDays(1);

        var result = await _query.GetByIntervalAsync(start, end);

        Assert.NotEmpty(result);
        Assert.Contains(machines, x => x.MaintenanceStart.Value >= start && x.MaintenanceReturn.Value < end);
        Assert.Single(result);
    }

    [Fact]
    public async Task Interval_WithNonExistingDates_ShouldReturnEmptyIEnumerable()
    {
        var start = new DateTime(2024, 12, 15);
        var end = new DateTime(2025, 1, 7).AddDays(1);

        var result = await _query.GetByIntervalAsync(start, end);

        Assert.Empty(result);
        Assert.DoesNotContain(machines, x => x.MaintenanceStart.Value >= start && x.MaintenanceReturn.Value < end);
    }

    [Theory]
    [InlineData("Empilhadeira")]
    [InlineData("Guindaste")]
    [InlineData("Bulldozer")]
    [InlineData("Trator")]
    public async Task Name_WithExistingString_ShouldReturnMachineEntity(string name)
    {
        var result = await _query.GetByNameAsync(name);

        Assert.NotNull(result);
        Assert.Contains(machines, x => x.Name.Value == name);
    }

    [Theory]
    [InlineData("Bc-009")]
    [InlineData("LH-541")]
    [InlineData("CH-123")]
    [InlineData("DG-002")]
    public async Task Name_WithNonExistingString_ShouldReturnNull(string name)
    {
        var machine = await _query.GetByNameAsync(name);

        Assert.Null(machine);
        Assert.DoesNotContain(machines, x => x.Name.Value == name);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(6)]
    [InlineData(2)]
    [InlineData(5)]
    public async Task MachType_WithExistingInt_ShouldReturnIEnumerableOfMachineEntity(int type)
    {
        var machines = await _query.GetByTypeAsync(type);

        Assert.NotEmpty(machines);
        Assert.Contains(machines, x => (int)x.MachType.Value == type);
    }

    [Theory]
    [InlineData(3)]
    [InlineData(4)]

    public async Task MachType_WithNonExistingInt_ShouldReturnEmptyIEnumerable(int type)
    {
        var machines = await _query.GetByTypeAsync(type);

        Assert.Empty(machines);
        Assert.DoesNotContain(machines, x => (int)x.MachType.Value == type);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public async Task Status_WithExistingInt_ShouldReturnIEnumerableOfMachineEntity(int type)
    {
        var machines = await _query.GetByStatusAsync(type);

        Assert.NotEmpty(machines);
        Assert.Contains(machines, x => (int)x.Status.Value == type);
    }

    [Theory]
    [InlineData(2)]
    public async Task Status_WithNonExistingInt_ShouldReturnEmptyIEnumerable(int type)
    {
        var machines = await _query.GetByStatusAsync(type);

        Assert.Empty(machines);
        Assert.DoesNotContain(machines, x => (int)x.Status.Value == type);
    }
}