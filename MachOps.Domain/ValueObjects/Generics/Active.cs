using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Generics;

public sealed class Active : ValueObject
{
    public bool Value { get; } = true;

    public Active() { }

    public Active(bool active) => Value = active;
}