using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Machines;

public sealed class Name : ValueObject
{
    public string Value { get; private set; } = null!;

    public Name(string name) => Value = name;

    public Name() { }
}