using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Generics;

public sealed class CreatedAt : ValueObject
{
    public DateTime Value { get; }

    public CreatedAt() => Value = DateTime.UtcNow;

    public CreatedAt(DateTime create) => Value = create;
}
