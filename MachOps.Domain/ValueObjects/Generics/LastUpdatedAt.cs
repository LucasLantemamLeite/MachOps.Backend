using MachOps.Domain.ValueObjects.Base;

namespace MachOps.Domain.ValueObjects.Generics;

public sealed class LastUpdatedAt : ValueObject
{
    public DateTime Value { get; }

    public LastUpdatedAt(DateTime update) => Value = update;

    public LastUpdatedAt()
    {
        Value = DateTime.UtcNow;
    }
}