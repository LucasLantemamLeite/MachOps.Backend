using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machinery;

public sealed class MachineryDescription : ValueObject
{
    public string? Value { get; } = null;

    public MachineryDescription(string? description) => Value = description;

    private MachineryDescription() { }
}