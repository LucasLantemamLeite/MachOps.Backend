using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machines;

public sealed class Location : ValueObject
{
    public string? Value { get; } = null;

    public Location(string? location) => Value = location;

    private Location() { }
}