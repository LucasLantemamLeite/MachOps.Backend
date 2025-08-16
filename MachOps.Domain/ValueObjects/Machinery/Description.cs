using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class Description : ValueObject
{
    public string? Value { get; } = null;

    public Description(string? description) => Value = description;

    private Description() { }
}