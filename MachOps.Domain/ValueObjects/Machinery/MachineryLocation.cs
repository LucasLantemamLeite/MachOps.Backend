using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class MachineryLocation : ValueObject
{
    public string? Value { get; } = null;

    public MachineryLocation(string? location) => Value = location;

    private MachineryLocation() { }
}